using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.UtilityResponse
{
    public static class LoggedResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static HttpResponseMessage Log(HttpResponseMessage response)
        {
            try
            {
                Console.WriteLine(string.Format("\t{0}", response));
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.WriteLine(string.Format("\t{0}", response.Content.ContentToString().Result));
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("\t{0}", e + " " + e.StackTrace));
                return ApiResponse.ReturnStatusCodeResponse(HttpStatusCode.BadRequest);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContent"></param>
        /// <returns></returns>
        public static async Task<string> ContentToString(this HttpContent httpContent)
        {
            return await httpContent.ReadAsStringAsync();
        }

    }

}
