using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNew.Services
{
    public class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\wpfcontacts.json";

        public FileService()
        {
            ReadFromFile();
        }

        public string ReadFromFile()
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }

            return string.Empty;
        }

        public void SaveToFile(string content)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
        }
    }
}
