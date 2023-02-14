using LocadoraFilmes.Models;
using LocadoraFilmes.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LocadoraFilmes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }


        // GET: ClienteController
        public ActionResult Index()
        {
            List<ClienteModel> lista = _clienteRepositorio.GetAll();

            return View(lista);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            ViewBag.Mensagem = "Dica: Evite problemas no cadastro e preencha os campos email e telefone corretamente ";
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModel objeto)
        {
            try
            {
                if (_clienteRepositorio.CheckNameExists(objeto.Nome))
                    ModelState.AddModelError("name", string.Concat(objeto.Nome, " já se encontra em nossos cadastros"));

                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Insert(objeto);

                    TempData["Mensagem"] = string.Concat("Cliente ", objeto.Nome, " cadastrado com sucesso!");

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(objeto);
                }
            }
            catch
            {
                TempData["Mensagem"] = "Erro no cadastro";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int Id)
        {
            var objeto = _clienteRepositorio.Get(Id);

            return View(objeto);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteModel objeto)
        {
            try
            {
                _clienteRepositorio.Update(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var objeto = _clienteRepositorio.Get(id);
            _clienteRepositorio.Delete(objeto);

            return RedirectToAction(nameof(Index));
        }

        
    }
}
