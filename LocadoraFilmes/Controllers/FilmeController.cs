using LocadoraFilmes.Models;
using LocadoraFilmes.Repositorio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace LocadoraFilmes.Controllers
{
    public class FilmeController : Controller
    {

        private readonly IFilmeRepositorio _filmeRepositorio;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilmeController(IFilmeRepositorio filmeRepositorio, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _filmeRepositorio = filmeRepositorio;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
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
                string dirCapas = _configuration.GetSection("AppSettings").GetValue<string>("IMAGENS_CAPAS");
                string dirServer = Path.Combine(_webHostEnvironment.WebRootPath, dirCapas);



                if (objeto.FotoCapa != null)
                {
                    long id = objeto.Id;//Nome do Arquivo

                    //1- Checar Extensão (no momento apenas PNG)
                    
                    var extensao = objeto.FotoCapa.FileName.Split('.')[1];
                    if (extensao.ToLower() != "png")
                    {
                        ModelState.AddModelError("name", string.Concat("Extensão de arquivo incorreta (somente PNG)"));
                    }
                    else
                    {
                        //Continuar Upload
                        using (var stream = System.IO.File.Create(dirServer + "/teste.png"))
                        {
                            objeto.FotoCapa.CopyTo(stream);
                        }

                    }



                }


                if (ModelState.IsValid)
                {

                    _filmeRepositorio.Update(objeto);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(objeto);
                }
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
