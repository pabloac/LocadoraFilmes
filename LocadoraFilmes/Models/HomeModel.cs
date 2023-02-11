using System;

namespace LocadoraFilmes.Models
{
    public class HomeModel
    {

        public void AtribuirValoresIniciais()
        {
            dataCorrente = DateTime.Now;
        }



        public DateTime? dataCorrente { get; set; }

    }
}
