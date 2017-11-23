using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;


namespace API.BaseAPI
{
    public class BaseAPIController : ApiController
    {
        public ApiResponse HttpResponse(int statusCode, string msg, object data)
        {

            //HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)statusCode,
            return new ApiResponse
            {
                code = statusCode,
                message = msg,
                data = data
            };
        }

        public ApiResponse HttpResponse(int statusCode, string msg)
        {

            //  HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)statusCode,
            return new ApiResponse
            {
                code = statusCode,
                message = msg,
            };
        }

        public ApiResponse ErrorResponse(int statusCode, string msg)
        {

            //HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)statusCode,
            return new ApiResponse
            {
                code = statusCode,
                message = msg,
            };
        }
        public ApiResponse ErrorResponse(string msg)
        {

            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest,
            return new ApiResponse
            {
                code = (int)HttpStatusCode.BadRequest,
                message = msg
            };
        }
    }

    public class ApiResponse
    {

        [Description("Status code representing states of response")]

        public int code { get; set; }

        [Description("Response message")]
        public string message { get; set; }

        [Description("Container of responsed data")]
        public dynamic data { get; set; }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class InfoAttribute : Attribute
    {
        public InfoAttribute(string info)
        {
            Information = info;
        }

        public string Information { get; private set; }
    }
}
