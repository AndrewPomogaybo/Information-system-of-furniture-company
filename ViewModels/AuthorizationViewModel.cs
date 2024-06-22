using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
namespace ShopMetta.ViewModels
{
    public class AuthorizationViewModel
    {
        private string captchaText;

        public string GetCaptchaText
        {
            get { return captchaText; }
        }
        
        public string GetName(string login, string pwd)
        {
            using (var db = new DataBaseContext())
            {
                var users = db.Users.ToList();
                var user = users.FirstOrDefault(u => Hasher.VerifyHash(u.User_login, login) && Hasher.VerifyHash(u.User_password, pwd));
                return user.User_name;
            }
        }

        public string GetSurname(string login, string pwd)
        {
            using (var db = new DataBaseContext())
            {
                var users = db.Users.ToList();
                var user = users.FirstOrDefault(u => Hasher.VerifyHash(u.User_login, login) && Hasher.VerifyHash(u.User_password, pwd));

                return user.User_surname;
            }
        }

        public int GetRole(string login, string pwd)
        {
            using (var db = new DataBaseContext())
            {
                var users = db.Users.ToList(); // Загружаем всех пользователей в память
                var user = users.FirstOrDefault(u => Hasher.VerifyHash(u.User_login, login) && Hasher.VerifyHash(u.User_password, pwd));

                return Convert.ToInt32(user.User_role);
            }
        }

        public void GenerateCaptcha(Image img)
        {
            img.Source = GenerateCaptchaImage(GenerateRandomText(5), 100, 100);
        }

        private string GenerateRandomText(int length)
        {
            Random random = new Random();
            string characters = "АБВГДЕЖЗИКЛМОПРНЙЦУГШЩХЪЭЮЯЬ123456789";

            for (int i = 0; i < length; i++)
            {
                captchaText += characters[random.Next(characters.Length)];
            }
            return captchaText;
        }

        private BitmapImage GenerateCaptchaImage(string text, int width, int height)
        {
            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawRectangle(Brushes.White, null, new Rect(0, 0, width, height));
                FormattedText formattedText = new FormattedText(
                    text,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Arial"),
                    24,
                    Brushes.Gray);
                drawingContext.DrawText(formattedText, new Point(10, 10));

                // Add noise and lines
                Random random = new Random();
                for (int i = 0; i < 50; i++)
                {
                    drawingContext.DrawRectangle(
                        new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256))),
                        null,
                        new Rect(random.Next(width), random.Next(height), 1, 1));
                }

                for (int i = 0; i < 10; i++)
                {
                    drawingContext.DrawLine(
                        new Pen(new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)), 1),
                        new Point(random.Next(width), random.Next(height)),
                        new Point(random.Next(width), random.Next(height)));
                }
            }
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(visual);
            BitmapImage bitmapImage = new BitmapImage();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Save(stream);
                stream.Seek(0, SeekOrigin.Begin);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }
    }
}
