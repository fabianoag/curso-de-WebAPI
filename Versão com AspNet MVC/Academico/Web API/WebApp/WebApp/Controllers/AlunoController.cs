using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// A controller da Web API 'Aluno'.
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        /// <summary>
        /// Consunta de alunos.
        /// </summary>
        /// <returns>Retorna uma lista de alunos.</returns>
        [HttpGet]
        [Route("Recuperar")]
        [Authorize(Roles = Funcao.Professor)]
        public IHttpActionResult Recuperar()
        {            
            try
            {
                AlunoModel alunos = new AlunoModel();
                return Ok(alunos.ListarAluno());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        
        [HttpGet]
        [Route("Recuperar/{id:int}/{nome?}/{sobrenome?}")]
        public IHttpActionResult RecuperarPorId(int id, string nome = null, string sobrenome = null)
        {
            try
            {
                AlunoModel alunos = new AlunoModel();
                return Ok(alunos.ListarAluno(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}/{idade:min(18)}")]
        public IHttpActionResult Recuperar(string data, string nome)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                IEnumerable<AlunoDTO> alunos = aluno.ListarAluno().Where(x => x.data == data || x.nome == nome);

                if (!alunos.Any())
                    return NotFound();

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        //[Authorize()]
        public IHttpActionResult Post(AlunoDTO aluno)
        {
            //Verifica se a erro de validação.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Inserir(aluno);

                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }


        }

        [HttpPut]//[FromBody]
        public IHttpActionResult Put(AlunoDTO aluno)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                _aluno.Atualizar(aluno);

                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Deletar(id);

                return Ok("Deletado com sucesso");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
