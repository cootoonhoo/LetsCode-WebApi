using System.ComponentModel.DataAnnotations;

namespace CadastroClientes.Core.Model
{
    public class Cliente
    {
        public Int64 Id { get; set; }
        [MaxLength(11, ErrorMessage = "Cpf deve conter 11 dígitos")]
        [MinLength(11, ErrorMessage = "Cpf deve conter 11 dígitos")]
        [Required(ErrorMessage = "Cpf é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime dataNascimento { get; set; }
        public int Idade
        {
            get
            {
                return (int)((DateTime.Now - dataNascimento).TotalDays / 365);
            }
            set { }
        }
    }
}