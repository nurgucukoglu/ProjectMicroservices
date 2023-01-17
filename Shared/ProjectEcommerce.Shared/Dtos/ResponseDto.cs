using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
        public static ResponseDto<T>Success(T Data, int statusCode)
        {
            return new ResponseDto<T>
            {
                Data = Data, 
                StatusCode = statusCode,
                IsSuccessful = true

            };
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T>
            {
                Data =default(T),
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }


        public static ResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string>() { error}, //tek hatayı göndericez, tek errora izin vermedi newledik
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
