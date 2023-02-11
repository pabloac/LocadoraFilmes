using LocadoraFilmes.Models;
using System.Collections.Generic;

namespace LocadoraFilmes.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Insert(UsuarioModel objeto);
        UsuarioModel Update(UsuarioModel objeto);
        UsuarioModel Delete(UsuarioModel objeto);
        List<UsuarioModel> GetAll();
        UsuarioModel Get(int id);
    }
}
