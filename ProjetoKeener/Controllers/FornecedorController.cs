using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoKeener.Dados.Repositorios;
using ProjetoKeener.Dados.Repositorios.Imp;
using ProjetoKeener.Entidades;
using ProjetoKeener.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio,
            IMapper mapper)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _mapper = mapper;
        }

        // GET: FornecedorController
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorRepositorio.BuscarTodos()));
        }

        // GET: FornecedorController/Details/5
        public ActionResult Details(int id)
        {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(_fornecedorRepositorio.BuscarPorId(id));
            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        // GET: FornecedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FornecedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            _fornecedorRepositorio.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            return RedirectToAction("Index");
        }

        // GET: FornecedorController/Edit/5
        public ActionResult Edit(int id)
        {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(_fornecedorRepositorio.BuscarPorId(id));
            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        // POST: FornecedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();

            var fornecedorAtualizacao = _mapper.Map<FornecedorViewModel>(_fornecedorRepositorio.BuscarPorId(id));

            if (!ModelState.IsValid) return View(fornecedorViewModel);

            fornecedorAtualizacao.Nome = fornecedorViewModel.Nome;
            fornecedorAtualizacao.TipoFornecedor = fornecedorViewModel.TipoFornecedor;
           // fornecedorAtualizacao.Estado = fornecedorViewModel.Estado;
            fornecedorAtualizacao.Ativo = fornecedorViewModel.Ativo;

            _fornecedorRepositorio.Alterar(_mapper.Map<Fornecedor>(fornecedorAtualizacao));

            return RedirectToAction("Index");
        }

        // GET: FornecedorController/Delete/5
        public ActionResult Delete(int id)
        {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(_fornecedorRepositorio.BuscarPorId(id));
            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        // POST: FornecedorController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConDeleteConfirmed(int id)
        {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(_fornecedorRepositorio.BuscarPorId(id));
            if (fornecedorViewModel == null) return NotFound();

            _fornecedorRepositorio.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}
