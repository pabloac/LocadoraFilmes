using LocadoraFilmes.Data;
using LocadoraFilmes.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraFilmes.Repositorio
{
    public class FilmeRepositorio : IFilmeRepositorio
    {

        private readonly BancoContext _bancoContext;


        public FilmeRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public FilmeModel Delete(FilmeModel objeto)
        {
            _bancoContext.Filmes.Remove(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public FilmeModel Get(int id)
        {
            return _bancoContext.Filmes.FirstOrDefault(x => x.Id == id);
        }

        public List<FilmeModel> GetAll()
        {
            return _bancoContext.Filmes.ToList();
        }

        public FilmeModel Insert(FilmeModel objeto)
        {
            _bancoContext.Filmes.Add(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public FilmeModel Update(FilmeModel objeto)
        {
            _bancoContext.Filmes.Update(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }
    }
}
