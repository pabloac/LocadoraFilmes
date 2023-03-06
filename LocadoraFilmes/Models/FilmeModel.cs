using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraFilmes.Models
{
    public class FilmeModel
    {
        public long Id { get; set; }
        
        [Required]
        public string Titulo { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Sinopse { get; set; }

        [Display(Name = "Classificação")]
        public int IdadeClassificacao { get; set; }


        [NotMapped]
        [Display(Name = "Foto da Capa")]
        public IFormFile FotoCapa { get; set; }


    }
}
