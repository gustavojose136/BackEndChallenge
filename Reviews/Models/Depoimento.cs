using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Reviews.Models
{
    public class Depoimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? DepoimentoTexto { get; set; }
        public string? Nome { get; set; }
        [SwaggerSchema(Format = "byte")]
        public byte[]? FotoPessoa { get; set; }
    }
}
