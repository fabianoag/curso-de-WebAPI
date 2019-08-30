using App.Domain;
using App.Repository;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{

    public class AlunoModel
    {

        /// <summary>
        /// Lista todos os alunos do banco de dados, você pode ou não passar o id do aluno.
        /// </summary>
        /// <param name="id">Recebe o id do</param>
        /// <returns>Retorna o resultado da pesquisa.</returns>
        public List<AlunoDTO> ListarAluno(int? id = null)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                return alunoBD.ListarAlunosDB(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }
            
        }
        
        /// <summary>
        /// Inseri um aluno no banco de dados.
        /// </summary>
        /// <param name="aluno">Recebe a entidade aluno para inserir.</param>
        public void Inserir(AlunoDTO aluno)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Inserir Aluno: Erro => {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza um aluno já existente no banco de dados.
        /// </summary>
        /// <param name="aluno">Recebe a entidade aluno para atualizar.</param>
        public void Atualizar(AlunoDTO aluno)
        {            
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Atualizar Aluno: Erro => {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um aluno por id.
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.DeleteAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Deletar o Aluno: Erro => {ex.Message}");
            }
        }

    }
}