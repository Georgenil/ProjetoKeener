using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoKeener.Dados.Repositorios;
using ProjetoKeener.Entidades;
using ProjetoKeener.Models;
using System;
using System.Collections.Generic;


namespace ProjetoKeener.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMovimentacaoRepositorio _movimentacaoRepositorio;
        private readonly IMapper _mapper;

        public MovimentacaoController(IProdutoRepositorio produtoRepositorio,
            IMovimentacaoRepositorio movimentacaoRepositorio,
            IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _movimentacaoRepositorio = movimentacaoRepositorio;
            _mapper = mapper;
        }

        // GET: MovimentacaoController1
        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepositorio.ObterMovimentacoesProdutos()));
        }

        public IActionResult Details(int id)
        {
            var movimentacaoViewModel = ObterMovimentacaoProduto(id);

            if (movimentacaoViewModel == null) return NotFound();

            return View(movimentacaoViewModel);
        }

        public ActionResult Create()
        {
            var movimentacaoViewModel = PopularProdutos(new MovimentacaoViewModel());

            return View(movimentacaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovimentacaoViewModel movimentacaoViewModel)
        {
            //movimentacaoViewModel = PopularProdutos(movimentacaoViewModel);

            if (!ModelState.IsValid) return View(movimentacaoViewModel);
            movimentacaoViewModel.Data = DateTime.Now;


            _movimentacaoRepositorio.Adicionar(_mapper.Map<Movimentacao>(movimentacaoViewModel));

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var movimentacaoViewModel = ObterMovimentacaoProduto(id);
            if (movimentacaoViewModel == null) return NotFound();

            return View(movimentacaoViewModel);
        }

       
        public IActionResult Delete(int id)
        {
            var movimentacaoViewModel = ObterMovimentacaoProduto(id);
            if (movimentacaoViewModel == null) return NotFound();

            return View(movimentacaoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movimentacaoViewModel = ObterMovimentacaoProduto(id);

            if (movimentacaoViewModel == null) return NotFound();

            _movimentacaoRepositorio.Excluir(id);

            return RedirectToAction("Index");
        }


        private MovimentacaoViewModel ObterMovimentacaoProduto(int id)
        {
            var movimentacao = _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepositorio.ObterMovimentacaoProduto(id));
            movimentacao.Produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepositorio.BuscarTodos());

            return movimentacao;
        }
        private MovimentacaoViewModel PopularProdutos(MovimentacaoViewModel movimentacao)
        {
            movimentacao.Produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepositorio.BuscarTodos());

            return movimentacao;
        }
    }
}
