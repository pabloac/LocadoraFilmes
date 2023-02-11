using LocadoraFilmes.Data;
using LocadoraFilmes.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraFilmes.Repositorio
{
    

    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContext _bancoContext;


        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Delete(UsuarioModel objeto)
        {
            _bancoContext.Usuarios.Remove(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public UsuarioModel Get(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> GetAll()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Insert(UsuarioModel objeto)
        {
            _bancoContext.Usuarios.Add(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public UsuarioModel Update(UsuarioModel objeto)
        {
            _bancoContext.Usuarios.Update(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }
    }
}
