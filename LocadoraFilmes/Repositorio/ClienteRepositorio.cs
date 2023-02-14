using LocadoraFilmes.Data;
using LocadoraFilmes.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraFilmes.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;


        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Delete(ClienteModel objeto)
        {
            _bancoContext.Clientes.Remove(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public ClienteModel Get(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> GetAll()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel Insert(ClienteModel objeto)
        {
            _bancoContext.Clientes.Add(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public ClienteModel Update(ClienteModel objeto)
        {
            _bancoContext.Clientes.Update(objeto);
            _bancoContext.SaveChanges();
            return objeto;
        }

        public bool CheckNameExists(string nome)
        {
            ClienteModel model = _bancoContext.Clientes.FirstOrDefault(x => x.Nome.ToLower().Contains(nome));

            if (model == null)
                return false;
            return true;
        }

    }
}
