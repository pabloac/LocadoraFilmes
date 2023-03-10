using LocadoraFilmes.Models;
using LocadoraFilmes.Repositorio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

                if (objeto.Id > 0 && objeto.FotoCapa != null)
                {
                    UploadImagemCapa(objeto);
                }

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

            string dirCapas = _configuration.GetSection("AppSettings").GetValue<string>("IMAGENS_CAPAS");
            string dirServer = Path.Combine(_webHostEnvironment.WebRootPath, dirCapas);
            string arquivo = string.Concat("/", objeto.Id, ".png");

            if (!System.IO.File.Exists(dirServer + arquivo))
                ViewBag.Imagem = string.Concat("/default.png");
            else
                ViewBag.Imagem = string.Concat(arquivo, "?", RandomString(6));

            return View(objeto);
        }


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        // POST: FilmeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmeModel objeto)
        {
            try
            {
                UploadImagemCapa(objeto);

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


        public void UploadImagemCapa(FilmeModel objeto)
        {

            try
            {
                string dirCapas = _configuration.GetSection("AppSettings").GetValue<string>("IMAGENS_CAPAS");
                string dirServer = Path.Combine(_webHostEnvironment.WebRootPath, dirCapas);

                if (objeto.FotoCapa != null)
                {
                    var extensao = objeto.FotoCapa.FileName.Split('.')[1];
                    if (extensao.ToLower() != "png")
                    {
                        ModelState.AddModelError("name", string.Concat("Extensão de arquivo incorreta (somente PNG)"));
                    }
                    else
                    {
                        string arquivo = string.Concat("/", objeto.Id, ".png");

                        //Continuar Upload (Salvar ou Sobrescrever)
                        using (var stream = System.IO.File.Create(dirServer + arquivo))
                        {
                            objeto.FotoCapa.CopyTo(stream);
                        }
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("name", string.Concat("Erro ao realizar o upload da foto."));
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
