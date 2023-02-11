using LocadoraFilmes.Models;
using System.Collections.Generic;

namespace LocadoraFilmes.Repositorio
{
    public interface IClienteRepositorio
    {
        ClienteModel Insert(ClienteModel objeto);
        ClienteModel Update(ClienteModel objeto);
        ClienteModel Delete(ClienteModel objeto);
        List<ClienteModel> GetAll();
        ClienteModel Get(int id);
    }
}
