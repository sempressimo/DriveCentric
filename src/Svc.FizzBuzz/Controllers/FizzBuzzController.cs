using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Svc.FizzBuzz.DTO;
using System.Threading.Tasks;
using DriveCentric.Domain;

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
            StandardFizzBuzz fizzBuzz = new StandardFizzBuzz();

            FizzBuzzResultDTO reponse = new FizzBuzzResultDTO
            {
                Values = fizzBuzz.GetList(request.MaxNumber, request.Divisor1, request.Divisor2, request.Word1, request.Word2)
            };

            _logger.LogInformation($"Request: Max: {request.MaxNumber}, Divisor 1: {request.Divisor1}, Divisor 2: {request.Divisor2}, Word 1: {request.Word1}, Word 2: {request.Word2}");

            return await Task.FromResult(reponse);
        }
    }
}
