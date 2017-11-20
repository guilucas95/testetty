using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTYClient.Models;
using TTYService;

namespace TTYClient.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public FornecedorController()
        {
            var teste = new TesteEntities();
        }
        public ActionResult Index()
        {
            FornecedorServiceClient forn = new FornecedorServiceClient();
            ViewBag.listaFornecedores = forn.obterTodos();
            return View();
        }
        [HttpGet]
        public ActionResult Novo()
        {
            FornecedorServiceClient forn = new FornecedorServiceClient();
            var fornecedor = new Fornecedor();
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Fornecedor fornecedor)
        {
            if (fornecedor.Id <= 0)
            {
                FornecedorServiceClient f = new FornecedorServiceClient();
                f.novo(fornecedor);
            }
            FornecedorServiceClient forn = new FornecedorServiceClient();
            forn.editar(fornecedor);
            return View("Novo");
        }

        public ActionResult Excluir(Fornecedor fornecedor)
        {
            FornecedorServiceClient forn = new FornecedorServiceClient();
            forn.excluir(fornecedor);
            return View("Index");
        }

    }
}