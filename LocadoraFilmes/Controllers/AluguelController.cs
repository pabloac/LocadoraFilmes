using LocadoraFilmes.Models;
using LocadoraFilmes.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocadoraFilmes.Controllers
{
    public class AluguelController : Controller
    {
        private readonly IAluguelRepositorio _aluguelRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IFilmeRepositorio _filmeRepositorio;

        public AluguelController(IAluguelRepositorio aluguelRepositorio, IClienteRepositorio clienteRepositorio, IFilmeRepositorio filmeRepositorio)
        {
            _aluguelRepositorio = aluguelRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _filmeRepositorio = filmeRepositorio;
        }


        // GET: AluguelController
        public ActionResult Index()
        {
            List<AluguelModel> lista = _aluguelRepositorio.GetAll();


            return View(lista);
        }

        // GET: AluguelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AluguelController/Create
        public ActionResult Create()
        {

            AluguelModel model = new AluguelModel();
            model.clientesSelecionar = _clienteRepositorio.GetAll();
            model.filmesSelecionar = _filmeRepositorio.GetAll();


            return View(model);
        }

        // POST: AluguelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AluguelModel objeto)
        {
            try
            {



                _aluguelRepositorio.Insert(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AluguelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AluguelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AluguelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AluguelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
