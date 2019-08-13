using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = Mapper
                .Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteApp.GetById(id));
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteApp.GetById(id));
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clienteViewModel = Mapper
                .Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetClientesEspeciais(_clienteApp
                    .GetAll()));

            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var clienteDomain = _clienteApp.GetById(id);

            if (clienteDomain == null)
            {
                return View("Index");
            }
            //Fonte - Dest
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(clienteDomain);

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel clienteViewModel)
        {
            var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
            _clienteApp.Remove(clienteDomain);

            return RedirectToAction("Index");
        }
    }
}