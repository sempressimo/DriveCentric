using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DriveCentric.Common
{
    public class ErrorInfo
    {
        [JsonPropertyName("code")]
        public ErrorCode? Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("stackTrace")]
        public string? StackTrace { get; set; }

        [JsonPropertyName("validationErrors")]
        public ValidationErrorCollection? ValidationErrors { get; set; }

        public ErrorInfo() { }

        public ErrorInfo(ErrorCode code, string message)
        {
            this.Code = code;
            this.Message = message;
        }


        public ErrorInfo(string message)
        {
            this.Message = message;
        }

        public ErrorInfo(Exception ex)
            : this(ex.Message)
        {
            this.StackTrace = ex.StackTrace;
        }
    }
}
