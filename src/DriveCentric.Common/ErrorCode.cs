using System;
using System.Collections.Generic;
using System.Text;

namespace DriveCentric.Common
{
    public enum ErrorCode
    {
        Unknown = 1,
        InternalServerError = 2,
        BadRequest = 3,
        ValidationError = 4,
        NotFound = 5,
        Unauthorized = 6,
        ServiceUnreachable = 7,
        InvalidToken = 8
    };

    public class ErrorCodesMapping
    {
        public ErrorCodesMapping()
        {

        }

        public int? Unknown { get; set; }
        public int? InternalServerError { get; set; }
        public int? BadRequest { get; set; }
        public int? ValidationError { get; set; }
        public int? NotFound { get; set; }
        public int? Unauthorized { get; set; }
        public int? ServiceUnreachable { get; set; }
        public int? InvalidToken { get; set; }
    }
}
