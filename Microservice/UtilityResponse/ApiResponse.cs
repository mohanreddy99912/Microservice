using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.UtilityResponse
{
    public class ApiResponse
    {
        /// <summary>
        /// Returns Json Response. 
        /// </summary>  
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static HttpResponseMessage ReturnJsonResponse<T>(T content)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content))
            };
        }

        /// <summary>
        /// Returns Status Code Response.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static HttpResponseMessage ReturnStatusCodeResponse(HttpStatusCode statusCode)
        {
            return new HttpResponseMessage(statusCode);
        }

        /// <summary>
        /// Returns Error Response along with stack trace
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static HttpResponseMessage ReturnErrorResponse(Exception ex)
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(ex.Message + ex.StackTrace)
            };
        }

    }

}
