using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(WebApp.Startup))]
/*
     

    INSTALAÇÕES DO 'Owin' NO PROMPT DO 'NuGet'
    ===========================================
    install-package Microsoft.AspNet.WebApi.Owin
    install-Package Microsoft.Owin.Host.SystemWeb
    install-Package Microsoft.Owin.Cors
*/


namespace WebApp
{
    /// <summary>
    /// Classe de inicialização do projeto.
    /// </summary>
    public class Startup
    {
        /*
            OBS:Esta classe de inicialização substitui o arquivos 'Global.asax' no projeto,
            basta fazer a instalações acima do Owin para isto, então você pode apagar o 'Global.asax'.
        */

        /// <summary>
        /// Configurações que serão usadas no Owin quando o projeto for inicializado.
        /// </summary>
        /// <param name="app">Recebe app.</param>
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

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

            config.EnableSwagger(c => {
                c.SingleApiVersion("v1", "WebApp");
                c.IncludeXmlComments(AppDomain.CurrentDomain.BaseDirectory + @"\bin\WebApp.xml");
            });

            app.UseCors(CorsOptions.AllowAll);

            AtivandoAccessTokens(app);

            app.UseWebApi(config);

        }

        /// <summary>
        /// Método privado de para acesso do token e as configuração do token.
        /// </summary>
        /// <param name="app">Recebe app.</param>
        private void AtivandoAccessTokens(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ProviderDeTokensDeAcesso()
            };

            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
