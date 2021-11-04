using DriveCentric.Domain;
using System;
using Xunit;

namespace FizzBuzzTests
{
    public class StandardFizzBuzzTest
    {
        StandardFizzBuzz _standardFizzBuzz = new StandardFizzBuzz();

        [Fact]
        public void ShouldFailOnInvalidArgument_MaxNumber()
        {
            Assert.Throws<ApplicationException>(() => _standardFizzBuzz.GetList(0, 1, 1, "", ""));
        }

        [Fact]
        public void ShouldFailOnInvalidArgument_Divisors()
        {
            Assert.Throws<ApplicationException>(() => _standardFizzBuzz.GetList(20, 0, 1, "", ""));

            Assert.Throws<ApplicationException>(() => _standardFizzBuzz.GetList(20, 1, 0, "", ""));
        }

        [Fact]
        public void ShouldReturn20Items()
        {
            var results = _standardFizzBuzz.GetList(20, 3, 5, "Fizz", "Buzz");

            Assert.True(results.Count == 20);
        }

        [Fact]
        public void ShouldReturnFizzAtPosition()
        {
            var results = _standardFizzBuzz.GetList(20, 3, 5, "Fizz", "Buzz");

            Assert.True(results[2] == "Fizz");
        }

        [Fact]
        public void ShouldReturnBuzzAtPosition()
        {
            var results = _standardFizzBuzz.GetList(20, 3, 5, "Fizz", "Buzz");

            Assert.True(results[4] == "Buzz");
        }
    }
}
