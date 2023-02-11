using LocadoraFilmes.Models;
using System.Collections.Generic;

namespace LocadoraFilmes.Repositorio
{
    public interface IFilmeRepositorio
    {
        FilmeModel Insert(FilmeModel objeto);
        FilmeModel Update(FilmeModel objeto);
        FilmeModel Delete(FilmeModel objeto);
        List<FilmeModel> GetAll();
        FilmeModel Get(int id);
    }
}
