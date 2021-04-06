using InnoCV.Model.ExceptionModel;
using InnoCVUserAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace InnoCVUserAPI.CustomExceptionMiddleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception Exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            ApiResult _customResult = null;

            switch (Exception)
            {
                case BaseCustomException e:
                    // custom application error
                    BaseCustomException _ex = e as BaseCustomException;
                    response.StatusCode = _ex.ErrorCode;
                    _customResult = new ApiResult { Code = _ex.ErrorCode, Message = _ex.Message };
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }


            string result;
            if (_customResult != null)
            {
                result = JsonSerializer.Serialize(_customResult);
            }
            else
            {
                result = JsonSerializer.Serialize(new { message = Exception?.Message });
            }

            return response.WriteAsync(result);
        }
    }
}
