using System;
using System.ComponentModel.DataAnnotations;

namespace LocadoraFilmes.Models
{
    public class AluguelModel
    {
        public long Id { get; set; }

        //public long ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteModel Cliente { get; set; }

        [Display(Name = "Filme")]
        public FilmeModel Filme { get; set; }

        [Display(Name = "Alugado em")]
        public DateTime? DtAluguel { get; set; }

        [Display(Name = "Entrega em")]
        public DateTime? DtPrevisaoEntrega { get; set; }
    }
}
