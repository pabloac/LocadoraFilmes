using System.ComponentModel.DataAnnotations;

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


    }
}
