using System.ComponentModel.DataAnnotations;

namespace CaseXP.Services.CupomAPI.Models
{
    public class Cupom
    {
        [Key]
        public int IdCupom { get; set; }
        [Required]
        public string CodigoCupom { get; set; }
        [Required]
        public double Desconto { get; set; }
        public int ValorMinimo { get; set; }
    }
}
