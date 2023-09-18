using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;

namespace Gerenciamento.Contas.Models
{
    public class BankAccount
    {
        [Required]
        public int Id { get; set;}

        [Required]
        public int CustomerId { get; set;} // Chave estrangeira para o Customer

        [Required(ErrorMessage = "O campo Balance é obrigatório.")]
        public decimal Balance { get; set; }

         public Customer Customer { get; set; } // Propriedade de navegação para Customer
    }
}