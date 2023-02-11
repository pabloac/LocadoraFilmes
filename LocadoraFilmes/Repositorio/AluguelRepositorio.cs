using LocadoraFilmes.Data;
using LocadoraFilmes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraFilmes.Repositorio
{
    public class AluguelRepositorio : IAluguelRepositorio
    {

        private readonly BancoContext _bancoContext;

        public AluguelRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AluguelModel Delete(AluguelModel objeto)
        {
            _bancoContext.Alugueis.Remove(objeto);
            _bancoContext.SaveChanges();
            return objeto; 
        }

        public AluguelModel Get(int id)
        {
            return _bancoContext.Alugueis.FirstOrDefault(x => x.Id == id);
        }

        public List<AluguelModel> GetAll()
        {
            return _bancoContext.Alugueis.Include(x => x.Cliente).Include(x => x.Filme).ToList();
        }

        public List<AluguelModel> GetAllPrazoEntrega(DateTime data)
        {
            return _bancoContext.Alugueis.Where(x => x.DtPrevisaoEntrega.Value.Date == data).ToList();  
        }

        public AluguelModel Insert(AluguelModel objeto)
        {
            _bancoContext.Alugueis.Add(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public AluguelModel Update(AluguelModel objeto)
        {
            _bancoContext.Alugueis.Add(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }
    }
}
