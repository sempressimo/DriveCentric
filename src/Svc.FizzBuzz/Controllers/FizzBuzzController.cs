using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Svc.FizzBuzz.DTO;
using System.Threading.Tasks;
using DriveCentric.Domain;
using DriveCentric.Application.Interfaces;

namespace Svc.FizzBuzz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly ILogger<FizzBuzzController> _logger;
        private readonly IFizzBuzz _fizzBuzz;

        public FizzBuzzController(ILogger<FizzBuzzController> logger, IFizzBuzz fizzBuzz)
        {
            _logger = logger;
            _fizzBuzz = fizzBuzz;
        }

        [HttpPost("Values")]
        public async Task<FizzBuzzResultDTO> GetResults([FromBody] FizzBuzzRequestDTO request)
        {
            FizzBuzzResultDTO reponse = new FizzBuzzResultDTO
            {
                Values = _fizzBuzz.GetList(request.MaxNumber, request.Divisor1, request.Divisor2, request.Word1, request.Word2)
            };

            _logger.LogInformation($"Request: Max: {request.MaxNumber}, Divisor 1: {request.Divisor1}, Divisor 2: {request.Divisor2}, Word 1: {request.Word1}, Word 2: {request.Word2}");

            return await Task.FromResult(reponse);
        }
    }
}
