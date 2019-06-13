using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models.Common
{
    public class DataResult<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public DataResult()
        {
            Success = true;
        }
    }

    public class DataResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public class DataResultBuilder
    {
        public static DataResult Success()
        {
            return new DataResult()
            {
                Success = true
            };
        }

        public static DataResult<T> Success<T>(T data)
        {
            return new DataResult<T>()
            {
                Data = data,
                Success = true
            };
        }

        public static DataResult Failed(string error)
        {
            return new DataResult()
            {
                Success = false,
                Message = error
            };
        }
    }
}
