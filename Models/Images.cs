using System.IO;


namespace ShopMetta.Models
{
    public class Images
    {
        public string DestinationPath { get; set; }

        public void CopyImage(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath, true);
        }
    }
}
