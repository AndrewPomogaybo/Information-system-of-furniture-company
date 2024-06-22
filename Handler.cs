using System.Windows.Controls;

namespace ShopMetta
{
    public static class Handler
    {
        public static void LowCharToUpper(TextBox text)
        {
            if (text.Text.Length > 0 && char.IsLower(text.Text[0]))
            {
                int cursorPos = text.SelectionStart;
                text.Text = char.ToUpper(text.Text[0]) + text.Text.Substring(1);
                text.SelectionStart = cursorPos;
            }
        }
    }
}
