using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoKeener.Dados.Repositorios;
using ProjetoKeener.Dados.Repositorios.Imp;
using ProjetoKeener.Data;
using ProjetoKeener.Entidades;
using ProjetoKeener.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepositorio produtoRepositorio,
                                  IFornecedorRepositorio fornecedorRepositorio,
                                  IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepositorio.ObterProdutosFornecedores()));
        }

        public IActionResult Details(int id)
        {
            var produtoViewModel = ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        public ActionResult Create()
        {
            var produtoViewModel = PopularFornecedores(new ProdutoViewModel());

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            // produtoViewModel = PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid) return View(produtoViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
            {
                return View(produtoViewModel);
            }

            produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;

            _produtoRepositorio.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var produtoViewModel = ObterProdutoFornecedor(id);
            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoAtualizacao = ObterProdutoFornecedor(id);
            //  produtoViewModel.Fornecedor = produtoAtualizacao.Fornecedor;
            produtoViewModel.Imagem = produtoAtualizacao.Imagem;

            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(produtoViewModel);
                }

                produtoAtualizacao.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            }

            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Obs = produtoViewModel.Obs;
            produtoAtualizacao.Preco = produtoViewModel.Preco;
            produtoAtualizacao.Disponivel = produtoViewModel.Disponivel;
            produtoAtualizacao.ImagemUpload = produtoViewModel.ImagemUpload;

            _produtoRepositorio.Alterar(_mapper.Map<Produto>(produtoAtualizacao));

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var produtoViewModel = ObterProdutoFornecedor(id);
            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produtoViewModel = ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            _produtoRepositorio.Excluir(id);

            return RedirectToAction("Index");
        }


        private ProdutoViewModel ObterProdutoFornecedor(int id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(_produtoRepositorio.ObterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorRepositorio.BuscarTodos());

            return produto;
        }

        private ProdutoViewModel PopularFornecedores(ProdutoViewModel produto)
        {
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorRepositorio.BuscarTodos());

            return produto;
        }

        private bool UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                arquivo.CopyTo(stream);
            }
            return true;
        }
    }
}
