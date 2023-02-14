using LocadoraFilmes.Data;
using LocadoraFilmes.Repositorio;
using System;
using System.Collections.Generic;
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
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }
        public string Celular { get; set; }
        
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? DtNascimento { get; set; }


    }
}
