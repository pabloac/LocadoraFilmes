using System;
using System.ComponentModel.DataAnnotations;

namespace LocadoraFilmes.Models
{
    public class ClienteModel
    {

        public ClienteModel()
        {

        }

        public ClienteModel(long id, string nome, string email, string celular, DateTime? dtNascimento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Celular = celular;
            DtNascimento = dtNascimento;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        
        [Display(Name = "Data de Nascimento")]
        public DateTime? DtNascimento { get; set; }
    }
}
