using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Svc.FizzBuzz.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Svc.FizzBuzz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly ILogger<FizzBuzzController> _logger;

        public FizzBuzzController(ILogger<FizzBuzzController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Values")]
        public async Task<FizzBuzzResultDTO> GetResults([FromBody] FizzBuzzRequestDTO request)
        {
            Svc.FizzBuzz.Business.FizzBuzz fizzBuzz = new Business.FizzBuzz();

            FizzBuzzResultDTO reponse = new FizzBuzzResultDTO
            {
                Values = fizzBuzz.GetList(request.MaxNumber, request.Divisor1, request.Divisor2, request.Word1, request.Word2)
            };

            return await Task.FromResult(reponse);
        }
    }
}
