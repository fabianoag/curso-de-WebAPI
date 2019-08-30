//using App.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteAspNetMVC.Models;
using System.Text;
using SiteAspNetMVC.Filters;

namespace SiteAspNetMVC.Controllers
{
    [AutorizacaoFilter]
    public class HomeController : Controller
    {        
        // GET: Home
        /// <summary>
        /// Lista todos os alunos do database.
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns>Retorna um lista alunos</returns>
        public ActionResult Index(string aluno = null)
        {
            CrieSessao sessao = new CrieSessao();
            var token = sessao.access_token;

            IList<AlunoDTO> _lista = null;
            if (token != "") {
                string ApiBaseUrl = "http://localhost:53387/api/"; // endereço da sua api
                string MetodoPath = "aluno/Recuperar"; //caminho do método a ser chamado

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "GET";
                    httpWebRequest.Headers.Add("Authorization", "bearer " + token);

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var resultado = JsonConvert.DeserializeObject<IList<AlunoDTO>>(streamReader.ReadToEnd());

                        _lista = resultado;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            ViewBag.token = token;

            return View(_lista);
        }

        /// <summary>
        /// Método que permite usar o POST e PUT da Web API.
        /// </summary>
        /// <param name="aluno">Recebe os dados do aluno.</param>
        /// <param name="tipo">Recebe o tipo de método, ex: atualiza ou cadastrar.</param>
        /// <returns>Retorna </returns>
        public ActionResult enviarForm(AlunoDTO aluno, string tipo = null)
        {
            //Se for atualizar recebe o id do aluno.
            string ApiBaseUrl = "http://localhost:53387/api/"; // endereço da sua api
            string MetodoPath = "aluno"; //caminho do método a ser chamado

            string dataPost = "";
            if (tipo == "atualiza")
            {
                dataPost = "Id=" + aluno.Id + "&";
            }
            dataPost += "nome=" + aluno.nome + "&" +
                       "sobrenome=" + aluno.sobrenome + "&" +
                       "telefone=" + aluno.telefone + "&" +
                       "ra=" + aluno.ra;            

            string _aluno = null;            
            try
            {
                var url = ApiBaseUrl + MetodoPath;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.ContentType = "application/x-www-form-urlencoded";

                if (tipo == "cadastra")
                {
                    httpWebRequest.Method = "POST";
                }
                else
                {
                    httpWebRequest.Method = "PUT";
                }

                //Passando dados para o httpwebRequest.
                var dados = Encoding.UTF8.GetBytes(dataPost);
                httpWebRequest.ContentLength = dados.Length;

                //precisamos escrever os dados post para o stream.
                using (var stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(dados, 0, dados.Length);
                    stream.Close();
                }

                //ler e exibir a resposta.
                using (var resposta = httpWebRequest.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();

                    //Instãncia e para os dados para SreamReader.
                    StreamReader reader = new StreamReader(streamDados);
                    string objResposta = reader.ReadToEnd();
                    _aluno = objResposta;
                }


            }
            catch (Exception e)
            {
                throw e;
            }

            return RedirectToAction("Index", "Home", new { aluno = _aluno });
        }

        /// <summary>
        /// Método usado para excluir o aluno.
        /// </summary>
        /// <param name="IdDel">Recebe o Id do aluno.</param>
        /// <returns></returns>
        public ActionResult excluirAluno(int IdDel = 0)
        {
            //Se for deletar recebe o id do aluno.
            if (IdDel != 0)
            {
                string ApiBaseUrl = "http://localhost:53387/api/"; // endereço da sua api
                string MetodoPath = "aluno/"+ IdDel; //caminho do método a ser chamado

                string _msg = null;
                try
                {
                    var url = ApiBaseUrl + MetodoPath;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.Method = "DELETE";

                    //ler e exibir a resposta.
                    using (var resposta = httpWebRequest.GetResponse())
                    {
                        var streamDados = resposta.GetResponseStream();

                        //Instãncia e para os dados para SreamReader.
                        StreamReader reader = new StreamReader(streamDados);
                        string objResposta = reader.ReadToEnd();
                        _msg = objResposta;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}