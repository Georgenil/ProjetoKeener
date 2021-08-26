using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoKeener.Dados.Repositorios;
using ProjetoKeener.Dados.Repositorios.Imp;
using ProjetoKeener.Data;
using ProjetoKeener.Entidades;
using ProjetoKeener.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        private string Session = "";
        public HomeController(ILogger<HomeController> logger
            , IUsuarioRepositorio usuarioRepositorio
            , IMapper mapper)
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            if (Session != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login(UsuarioViewModel u)
        {
            // esta action trata o post (login)
            //if (!ModelState.IsValid) //verifica se é válido
            //{
                using (SqlContext _connection = new SqlContext())
                {
                    var v = _connection.Usuarios.Where(a => a.Login.Equals(u.Login) && a.Senha.Equals(u.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session = v.Id.ToString();
                        Session = v.Login.ToString();
                        return RedirectToAction("Index");
                    }
                }
            //}
            return View(u);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(UsuarioViewModel u)
        {
            if (!ModelState.IsValid) return View(u);

            _usuarioRepositorio.Adicionar(_mapper.Map<Usuario>(u));

            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
