using LocadoraFilmes.Models;
using LocadoraFilmes.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocadoraFilmes.Controllers
{
    public class FilmeController : Controller
    {

        private readonly IFilmeRepositorio _filmeRepositorio;

        public FilmeController(IFilmeRepositorio filmeRepositorio)
        {
            _filmeRepositorio = filmeRepositorio;
        }



        // GET: FilmeController
        public ActionResult Index()
        {
            List<FilmeModel> lista = _filmeRepositorio.GetAll();

            return View(lista);
        }

        // GET: FilmeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmeModel objeto)
        {
            try
            {
                _filmeRepositorio.Insert(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmeController/Edit/5
        public ActionResult Edit(int Id)
        {
            var objeto = _filmeRepositorio.Get(Id);

            return View(objeto);
        }

        // POST: FilmeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmeModel objeto)
        {
            try
            {
                _filmeRepositorio.Update(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmeController/Delete/5
        public ActionResult Delete(int id)
        {
            var objeto = _filmeRepositorio.Get(id);
            _filmeRepositorio.Delete(objeto);

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Acervo()
        {
            List<FilmeModel> lista = _filmeRepositorio.GetAll();

            return View(lista);
        }


    }
}
