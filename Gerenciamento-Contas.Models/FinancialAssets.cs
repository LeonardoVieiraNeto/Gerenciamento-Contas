using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;

namespace Gerenciamento.Contas.Models
{
    public class FinancialAssets
    {
        [Required]
        public int Id { get; set;}

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Price é obrigatório.")]
        public decimal Price { get; set; }
    }
}