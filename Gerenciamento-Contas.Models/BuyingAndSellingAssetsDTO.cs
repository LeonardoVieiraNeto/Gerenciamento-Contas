using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciamento.Contas.Models
{
public class BuyingAndSellingAssetsDTO
{
    [Required]
    public int AccountID { get; set;}

    [Required]
    public string Type { get; set;} 

    [Required(ErrorMessage = "O campo Balance é obrigatório.")]
    public int AssetID { get; set; }

    [Required(ErrorMessage = "O campo Balance é obrigatório.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "O campo Balance é obrigatório.")]
    public decimal TotalValue { get; set; }

    [Required(ErrorMessage = "O campo Balance é obrigatório.")]
    public DateTime Date { get; set; }
}
}

