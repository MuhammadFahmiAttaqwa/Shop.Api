using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Response
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Code { get; set; }
        public T Data { get; set; } = default!;
        public List<string>? Errors { get; set; }

        public static ApiResponse<T> Success(T data, string message = "successful")
        {
            return new ApiResponse<T>
            {
                Status = true,
                Code = "200",
                Message = message,
                Data = data,
                Errors = null
            };
        }

        public static ApiResponse<T> Failure(string message, string? errorCode = null, List<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                Status = false,
                Message = message,
                Code = errorCode,
                Data = default!,
                Errors = errors ?? new List<string>()
            };
        }



    }
}
