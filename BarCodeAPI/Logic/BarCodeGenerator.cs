using DataMatrix.NetCore;
using System.Drawing.Imaging;
using System.Drawing;
using BarCodeAPI.Interfaces;

namespace BarCodeAPI.Logic
{
    public class BarCodeGenerator : IBarCodeGenerator
    {
        private readonly string _saveImageDirectory;
        public BarCodeGenerator(IConfiguration configuration) 
        {
            _saveImageDirectory = configuration["SaveImageDirectory"]?.ToString() ?? string.Empty;
        }

        public void Generate(string data)
        {
            var encoder = new DmtxImageEncoder();
            var encoderOptions = new DmtxImageEncoderOptions
            {
                ModuleSize = 8,
                MarginSize = 4,
                BackColor = Color.White,
                ForeColor = Color.Green
            };
            encoder.EncodeImage(data, encoderOptions).Save($"{_saveImageDirectory}{GenerateFileName()}", ImageFormat.Png);
        }

        private string GenerateFileName() => $"{DateTime.Now.ToString("dd-MM-yyyy-hhmmss")}.png";
    }
}
