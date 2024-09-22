using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;
using TelemetryPortal_MVC.Repisitory;

namespace TelemetryPortal_MVC.Controllers
{
    public class ClientsController : Controller
    {

        private readonly IClientRepository _clientRepository;


        public ClientsController(TechtrendsContext context, IClientRepository clientRepository)
        {

            _clientRepository = clientRepository;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var results = _clientRepository.GetAll();
            return View(results);

        }

        // GET: Clients/Details/5
        // GET: Projects/Details/5
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(Guid? id)
        {
            var results = await _clientRepository.GetClientByIdAsync(id);
            if (results == null)
            {
                return NotFound();
            }

            var client = _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientName,PrimaryContactEmail,DateOnboarded")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = Guid.NewGuid();
                _clientRepository.CreateClientAsync(client);

                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ClientId,ClientName,PrimaryContactEmail,DateOnboarded")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _clientRepository.Update(client);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            await _clientRepository.DeleteClientAsync(id);
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client != null)
            {
                _clientRepository.Remove(client);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(Guid id)
        {
            return _clientRepository.ClientExists(id);
        }
    }
}
