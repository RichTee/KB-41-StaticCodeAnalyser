using StatischeCodeAnalyse.Models;
using StatischeCodeAnalyse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Services
{
    class ResponseService
    {
        public Response Success(string message, string additional)
        {
            Response response = new Response(StatusCode.SUCCESS, message, additional);            
            return response;
        }

        public Response CustomError(StatusCode statusCode, string message, string additional)
        {
            Response response = new Response(statusCode, message, additional);
            return response;
        }

        public Response Exception(Exception exception, string additional)
        {
            Response response = new Response(StatusCode.EXCEPTION, exception.Message, additional);
            return response;
        }
    }
}
