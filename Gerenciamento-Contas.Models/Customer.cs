using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciamento.Contas.Models
{
    public class Customer
    {
        [Required]
         [Key] // Use a atribuição [Key] para indicar que a propriedade é a chave primária
        public int Id { get; set;}

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        public string Password { get; set;}

        public decimal TotalBalance { get; set;}

        public List<BankAccount> Accounts { get; set; }
    }
}