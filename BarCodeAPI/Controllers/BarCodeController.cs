using BarCodeAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarCodeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarCodeController : ControllerBase
    {
        private readonly IBarCodeGenerator _barCodeGenerator;
        public BarCodeController(IBarCodeGenerator generator) 
        {
            _barCodeGenerator = generator;
        }

        [HttpPost]
        public void GenerateDataMatrix([FromBody]string input)
        {
            _barCodeGenerator.Generate(input);
        }
    }
}
