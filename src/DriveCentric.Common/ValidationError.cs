using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DriveCentric.Common
{
    public class ValidationError
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
