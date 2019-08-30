using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Repository
{
    public class AlunoDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private IDbConnection conexao;

        /// <summary>
        /// Método construtor da class AlunoDAO.
        /// </summary>
        public AlunoDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        /// <summary>
        /// Método para lista alunos por id.
        /// </summary>
        /// <param name="id">Recebe o id do aluno.</param>
        /// <returns>Retorna uma lista</returns>
        public List<AlunoDTO> ListarAlunosDB(int? id)
        {
            var listaAlunos = new List<AlunoDTO>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                if (id == null)
                {
                    selectCmd.CommandText = "select * from Alunos";
                }
                else
                {
                    selectCmd.CommandText = $"select * from Alunos where id = {id}";
                }
                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var alu = new AlunoDTO()
                    {
                        Id = Convert.ToInt32(resultado["Id"]),
                        nome = Convert.ToString(resultado["nome"]),
                        sobrenome = Convert.ToString(resultado["sobrenome"]),
                        telefone = Convert.ToString(resultado["telefone"]),
                        ra = Convert.ToInt32(resultado["ra"])
                    };
                    listaAlunos.Add(alu);
                }
                return listaAlunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Método para inserir aluno.
        /// </summary>
        /// <param name="aluno">Recebo o entidade aluno.</param>
        public void InserirAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Alunos (nome, sobrenome, telefone, ra) values (@nome, @sobrenome, @telefone, @ra)";

                IDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                insertCmd.Parameters.Add(paramNome);

                IDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                insertCmd.Parameters.Add(paramSobrenome);

                IDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                insertCmd.Parameters.Add(paramTelefone);

                IDataParameter paramRa = new SqlParameter("ra", aluno.ra);
                insertCmd.Parameters.Add(paramRa);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }



        }

        /// <summary>
        /// Método para atualizar o aluno.
        /// </summary>
        /// <param name="aluno">Recebe a enditade aluno.</param>
        public void AtualizarAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand updatetCmd = conexao.CreateCommand();
                updatetCmd.CommandText = "update Alunos set nome = @nome, sobrenome = @sobrenome, telefone = @telefone, ra = @ra where Id = @Id";

                IDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                IDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                IDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                IDataParameter paramRa = new SqlParameter("ra", aluno.ra);
                updatetCmd.Parameters.Add(paramNome);
                updatetCmd.Parameters.Add(paramSobrenome);
                updatetCmd.Parameters.Add(paramTelefone);
                updatetCmd.Parameters.Add(paramRa);

                IDataParameter paramId = new SqlParameter("Id", aluno.Id);
                updatetCmd.Parameters.Add(paramId);

                updatetCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Método para deletar aluno por id.
        /// </summary>
        /// <param name="Id">Recebe o id do aluno.</param>
        public void DeleteAlunoDB(int Id)
        {
            try
            {
                IDbCommand deletetCmd = conexao.CreateCommand();
                deletetCmd.CommandText = "delete from Alunos where Id = @Id";

                IDataParameter paramId = new SqlParameter("Id", Id);
                deletetCmd.Parameters.Add(paramId);

                deletetCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}