using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            

            // Serviços e configuração da API da Web
            config.EnableCors();
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            //OBS => OBTER MAIS INFORMAÇÕES SOBRE ESTE TRECHO,
            //POIS EU NÃO ENTENDO ESTA TRECHO.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
