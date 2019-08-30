using Newtonsoft.Json;
using SiteAspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SiteAspNetMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string email, string senha , string erro)
        {
            string _erro = null;
            UserTokenDTO dadosUser = null;
            if (email != null && senha != null)
            {
                string ApiBaseUrl = "http://localhost:53387/"; // endereço da sua api
                string MetodoPath = "token"; //caminho do método a ser chamado

                string dataPost = "";

                dataPost += "username=" + email + "&" +
                            "password=" + senha + "&" +
                            "grant_type=password";
              
                //AlunoDTO _aluno = null;//Verificar depois
                try
                {
                    var url = ApiBaseUrl + MetodoPath;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";

                    httpWebRequest.Method = "POST";

                    

                    //Passando dados para o httpwebRequest.
                    var dados = Encoding.UTF8.GetBytes(dataPost);
                    httpWebRequest.ContentLength = dados.Length;

                    //precisamos escrever os dados post para o stream.
                    using (var stream = httpWebRequest.GetRequestStream())
                    {
                        stream.Write(dados, 0, dados.Length);
                       
                        stream.Close();
                    }

                    var teste = httpWebRequest.UserAgent;
                    //ler e exibir a resposta.
                    using (var resposta = httpWebRequest.GetResponse())
                    {

                        var streamDados = resposta.GetResponseStream();

                        //Instãncia e para os dados para SreamReader.
                        StreamReader reader = new StreamReader(streamDados);
                        string objResposta = reader.ReadToEnd();

                        UserTokenDTO resultado = JsonConvert.DeserializeObject<UserTokenDTO>(objResposta);

                        dadosUser = resultado;                      
                    }
                }
                catch (Exception e)
                {
                    
                    switch (e.HResult)
                    {
                        case -2146233079:
                            _erro = "Login ou senha estão incorretas!";
                            break;
                        default:
                            _erro = e.Message;
                            break;
                    }                  
                }                
            }

            if (_erro != null)
            {
                ViewBag.erroVal = _erro;
                ModelState.AddModelError("ErroLogin", _erro);
            }
            if (dadosUser != null)
            {
                CrieSessao ses = new CrieSessao();
                ses.access_token = dadosUser.access_token;
                ses.username = dadosUser.Username;
                return RedirectToAction("Index", "Home");                
            }

            return View();
        }

        public ActionResult Sair()
        {

            HttpContext.Session["username"] = null;
            HttpContext.Session["token"] = null;
            return RedirectToAction("Index","Login");
        }

    }
}