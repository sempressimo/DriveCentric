using System;
using System.Diagnostics.CodeAnalysis;

namespace DriveCentric.Common
{
    public class ApiResponse
    {
        /// <summary>
        /// Whether or not the request was successful.
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// If the request was unsuccessful, contains information about the error
        /// that occurred.
        /// </summary>
        public ValidationErrorCollection? Error { get; set; }

        #region Generic Error

        public static ApiResponse<T> GenericError<T>(ValidationErrorCollection error)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = error,
                Data = default
            };
        }

        public static ApiResponse<object> GenericError(ValidationErrorCollection error)
            => GenericError<object>(error);

        public static ApiResponse<object> GenericError(ErrorCode errorCode, string message)
            => GenericError<object>(errorCode, message);

        public static ApiResponse<T> GenericError<T>(ErrorCode errorCode, string message)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(errorCode, message),
                Data = default
            };
        }

        #endregion

        public static ApiResponse<object> Success()
            => Success<object>(null);

        public static ApiResponse<T> Success<T>([AllowNull] T data)
        {
            return new ApiResponse<T>()
            {
                Data = data,
                Successful = true
            };
        }

        #region Validation Error

        public static ApiResponse<object> ValidationError(ValidationErrorCollection validationErrors)
            => ValidationError<object>(validationErrors);

        public static ApiResponse<T> ValidationError<T>(ValidationErrorCollection validationErrors)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Data = default,
                Error = new ValidationErrorCollection(ErrorCode.ValidationError, "Validation Error")
                {
                    ValidationErrors = validationErrors
                }
            };
        }

        #endregion

        #region Not Found

        public static ApiResponse<object> NotFound()
            => NotFound<object>();

        public static ApiResponse<object> NotFound(string message)
            => NotFound<object>("Not Found");

        public static ApiResponse<T> NotFound<T>()
            => NotFound<T>("Not Found");

        /// <summary>
        /// Creates a new ApiResponse indicating the record was not found.
        /// response.
        /// </summary>
        /// <returns></returns>
        public static ApiResponse<T> NotFound<T>(string message)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.NotFound, message)
            };
        }

        #endregion

        #region Unauthorized

        /// <summary>
        /// Creaets a new ApiResponse object for an Unauthorized
        /// response.
        /// </summary>
        /// <returns></returns>
        public static ApiResponse<T> Unauthorized<T>(string message)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.Unauthorized, message)
            };
        }

        public static ApiResponse<object> Unauthorized(string message)
            => Unauthorized<object>(message);

        public static ApiResponse<T> Unauthorized<T>()
            => Unauthorized<T>("Unauthorized");

        public static ApiResponse<object> Unauthorized()
            => Unauthorized<object>("Unauthorized");

        #endregion

        #region Invalid Token
        public static ApiResponse<object> InvalidToken()
            => InvalidToken("Invalid Token");

        public static ApiResponse<object> InvalidToken(string message)
        {
            return new ApiResponse<object>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.InvalidToken, message)
            };
        }
        #endregion

        #region Bad Request

        public static ApiResponse<object> BadRequest()
            => BadRequest<object>("Bad Request");

        public static ApiResponse<object> BadRequest(string message)
            => BadRequest<object>(message);

        public static ApiResponse<T> BadRequest<T>()
            => BadRequest<T>("Bad Request");

        public static ApiResponse<T> BadRequest<T>(string message)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.BadRequest, message)
            };
        }

        #endregion

        #region Unknown Error
        public static ApiResponse<object> UnknownError()
            => UnknownError<object>("Unknown Error");

        public static ApiResponse<object> UnknownError(string message)
            => UnknownError<object>(message);

        public static ApiResponse<T> UnknownError<T>()
            => UnknownError<T>("Unknown Error");

        public static ApiResponse<T> UnknownError<T>(string message)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.Unknown, message)
            };
        }

        #endregion

        #region Internal Server Error

        /// <summary>
        /// Returns a generic internal server error response.
        /// </summary>
        /// <returns></returns>
        public static ApiResponse<object> InternalServerError()
            => InternalServerError<object>();

        /// <summary>
        /// Returns a generic internal server error response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ApiResponse<T> InternalServerError<T>()
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.InternalServerError, "Internal Server Error")
            };
        }

        /// <summary>
        /// Creates an internal server error response for the specified exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static ApiResponse<T> InternalServerError<T>(Exception ex)
            => InternalServerError<T>(ex.Message);

        /// <summary>
        /// Creates an internal server error response with the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse<T> InternalServerError<T>(string message)
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.InternalServerError, message)
            };
        }

        #endregion

        public static ApiResponse<T> ServiceUnreachable<T>()
        {
            return new ApiResponse<T>()
            {
                Successful = false,
                Error = new ValidationErrorCollection(ErrorCode.ServiceUnreachable, "Service Unreachable")
            };
        }
    }


    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        /// Response data.
        /// </summary>
        [AllowNull]
        [MaybeNull]
        public T Data { get; set; }

        public ApiResponse()
            : this(default)
        { }

        public ApiResponse([AllowNull] T data)
        {
            this.Data = data;
        }
    }
}
