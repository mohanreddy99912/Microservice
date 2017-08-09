using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Swagger;
using Swashbuckle.Application;
//using System.Web.Http;
//using System.Web.Http.HttpConfiguration;


namespace Microservice
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();
            Config.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
            //appBuilder.UseStaticFiles("/StaticContent");
            //appBuilder.UseStaticFiles("/StaticContent");

            httpConfiguration
                .EnableSwagger(c => c.SingleApiVersion("v1", "Microservice "))
                .EnableSwaggerUi();
        }
    }

}
