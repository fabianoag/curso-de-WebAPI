using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Domain
{
    /// <summary>
    /// Entidade aluno usada para transferência de dados, nele contém algumas restrições.
    /// </summary>
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é de Preenchimento e Obrigatório")]
        [StringLength(maximumLength:50, ErrorMessage = "Nome tem no minimo 2 caracteres e no maximo 50.", MinimumLength = 3)]
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }

        [RegularExpression(@"[0-9]{4}\-[0-9]{2}", ErrorMessage = "A data está forá do formato YYYY-MM.")]
        public string data { get; set; }

        [Required(ErrorMessage = "O RA é de Preenchimento e Obrigatório.")]
        [Range(1,9099,ErrorMessage = "O intervalo para cadastro de RA está entre 1 e 9099.")]
        public int? ra { get; set; }
    }
}