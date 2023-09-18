using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;

namespace Gerenciamento.Contas.Models
{
    public class FinancialTransaction
    {
        [Required]
        public int Id { get; set;}

        [Required(ErrorMessage = "O campo AccountId é obrigatório.")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "O campo Type é obrigatório.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "O campo AssetID é obrigatório.")]
        public int AssetID { get; set;}

        [Required(ErrorMessage = "O campo Quantity é obrigatório.")]
        public int Quantity { get; set;}

        [Required(ErrorMessage = "O campo TotalValue é obrigatório.")]
        public decimal TotalValue { get; set;}

        [Required(ErrorMessage = "O campo Date é obrigatório.")]
        public DateTime Date { get; set;}
    }
}