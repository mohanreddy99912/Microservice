using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microservice.Filters;
using System.Net.Http;
using Microservice.UtilityResponse;
using gmailbreakup;

namespace Microservice.WebAPI
{
    public class GmailController : ApiController
    {
       
        public gmail mail;
        [HttpPost]
        [Diagnostic]
        public async Task<HttpResponseMessage> UserID(String Mailid)
        {
            mail = new gmail();
            try
            {
                var result = mail.gmailusername(Mailid);
                // return LoggedResponse.Log(ApiResponse.ReturnJsonResponse(UserID));
                return LoggedResponse.Log(ApiResponse.ReturnJsonResponse(result));

            }
            catch(Exception ex)
            {
                return LoggedResponse.Log(ApiResponse.ReturnErrorResponse(ex));
            }
        
        
        }

    }
}
