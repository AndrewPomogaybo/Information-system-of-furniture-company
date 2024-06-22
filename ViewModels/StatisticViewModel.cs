using Microsoft.Win32;
using ShopMetta.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ShopMetta.ViewModels
{
    public class StatisticViewModel
    {
        public StatisticViewModel(TextBlock product, TextBlock totalQuantity, TextBlock totalRevenue, Canvas salesCanvas,Button btn) 
        {
            LoadStatistics(product, totalQuantity, totalRevenue, salesCanvas);

            if (btn.Name == "ExportReport")
                ExportStatisticsToWord(salesCanvas,totalQuantity,totalRevenue);
        }


        private void LoadStatistics(TextBlock product, TextBlock totalQuantity, TextBlock totalRevenue, Canvas salesCanvas)
        {
            using (var context = new DataBaseContext())
            {
                var productStats = context.ProductStatistics.ToList();
                var overallStats = context.OverallStatistics.FirstOrDefault();

                StringBuilder sb = new StringBuilder();
                foreach (var ps in productStats)
                {
                    sb.AppendLine($"Товар: {ps.ProductName}, Продано: {ps.QuantitySold}, Сумма: {ps.TotalRevenue}");
                }

                product.Text = sb.ToString();
                DrawGraph(productStats, salesCanvas);
                if (overallStats != null)
                {
                    totalQuantity.Text = $"{overallStats.TotalQuantitySold}";
                    totalRevenue.Text = $"{overallStats.TotalRevenue}";
                }
                else
                {
                    totalQuantity.Text = "0";
                    totalRevenue.Text = "0";
                }
            }
        }


        private void DrawGraph(List<ProductStatistic> productStats, Canvas salesCanvas)
        {
            salesCanvas.Children.Clear();

            if (productStats.Count == 0) return;

            double canvasWidth = salesCanvas.Width; // Учитываем отступ для оси
            double canvasHeight = salesCanvas.Height;
            double maxQuantity = productStats.Max(ps => ps.QuantitySold);
            double barWidth = canvasWidth / productStats.Count;

            // Рисование оси Y и меток
            for (int i = 0; i <= 5; i++)
            {
                double y = canvasHeight - (i * canvasHeight / 5);
                Line line = new Line
                {
                    X1 = 50,
                    Y1 = y,
                    X2 = canvasWidth + 50,
                    Y2 = y,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 0.5
                };
                salesCanvas.Children.Add(line);

                TextBlock label = new TextBlock
                {
                    Text = (maxQuantity * i / 5).ToString(),
                    FontSize = 10,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center
                };
                Canvas.SetLeft(label, 5);
                Canvas.SetTop(label, y - 10);
                salesCanvas.Children.Add(label);
            }

            // Рисование баров
            for (int i = 0; i < productStats.Count; i++)
            {
                double barHeight = (productStats[i].QuantitySold / maxQuantity) * canvasHeight;
                Rectangle rect = new Rectangle
                {
                    Width = barWidth - 10,
                    Height = barHeight,
                    Fill = Brushes.Blue
                };

                Canvas.SetLeft(rect, i * barWidth + 55);
                Canvas.SetBottom(rect, 0);
                salesCanvas.Children.Add(rect);

                TextBlock label = new TextBlock
                {
                    Text = productStats[i].ProductName,
                    RenderTransform = new RotateTransform(-45),
                    FontSize = 10
                };
                Canvas.SetLeft(label, i * barWidth + 55);
                Canvas.SetBottom(label, barHeight + 5);
                salesCanvas.Children.Add(label);
            }
        }



        private void ExportStatisticsToWord(Canvas salesCanvas, TextBlock TotalQuantityTextBlock, TextBlock TotalRevenueTextBlock)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "DOCX files (*.docx)|*.docx",
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string img = System.IO.Path.GetFullPath($"StatisticsReport.png");
                var doc = DocX.Create(filePath);

                SaveCanvasAsImage(salesCanvas, img);

                doc.InsertParagraph("Отчет по продажам")
                    .FontSize(30)
                    .Bold()
                    .Alignment = Alignment.center;

                doc.InsertParagraph("");

                doc.InsertParagraph($"Дата создания отчета: {DateTime.Now}")
                    .FontSize(20)
                    .Bold()
                    .Alignment = Alignment.right;

                doc.InsertParagraph("");

                doc.InsertParagraph($"Общее количество продаж: {TotalQuantityTextBlock.Text}")
                    .FontSize(20)
                    .Bold()
                    .SpacingAfter(10);

                doc.InsertParagraph("");

                doc.InsertParagraph($"Общая сумма: {TotalRevenueTextBlock.Text}")
                    .FontSize(20)
                    .Bold()
                    .SpacingAfter(20);

                doc.InsertParagraph("");

                using (var context = new DataBaseContext())
                {
                    var productStats = context.ProductStatistics.ToList();

                    foreach (var ps in productStats)
                    {
                        doc.InsertParagraph($"Товар: {ps.ProductName}, Количество продаж: {ps.QuantitySold}, Сумма: {ps.TotalRevenue}")
                            .FontSize(15);
                    }


                    doc.InsertParagraph("");
                    var image = doc.AddImage(img);
                    var picture = image.CreatePicture();
                    doc.InsertParagraph().AppendPicture(picture).Alignment = Alignment.center;

                }


                doc.Save();
                MessageBox.Show($"Отчет успешно экспортирован {filePath}", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                Process.Start(new ProcessStartInfo(filePath));
            }
        }



        private void SaveCanvasAsImage(Canvas canvas, string filename)
        {
            double dpi = 96d;
            Size size = new Size(canvas.ActualWidth, canvas.ActualHeight);

            canvas.Measure(size);
            canvas.Arrange(new Rect(size));

            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)size.Width, (int)size.Height,
                dpi, dpi, PixelFormats.Pbgra32);

            renderBitmap.Render(canvas);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
    }
}
