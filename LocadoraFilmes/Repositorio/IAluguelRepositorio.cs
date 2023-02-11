using LocadoraFilmes.Models;
using System;
using System.Collections.Generic;

namespace LocadoraFilmes.Repositorio
{
    public interface IAluguelRepositorio
    {
        AluguelModel Insert(AluguelModel objeto);
        AluguelModel Update(AluguelModel objeto);
        AluguelModel Delete(AluguelModel objeto);
        List<AluguelModel> GetAll();
        List<AluguelModel> GetAllPrazoEntrega(DateTime data);
        AluguelModel Get(int id);
    }
}
