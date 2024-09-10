using Microsoft.EntityFrameworkCore.Infrastructure;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


namespace TelemetryPortal_MVC.Repisitory
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
       
        public ClientRepository(TechtrendsContext context) : base(context)
        {

        }
        //TechtrendsContext _context;

    
       /* public ClientRepository(TechtrendsContext context)
        {
            _context = context;
        }*/
       public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public async Task<Client> GetClientByIdAsync(Guid? id)
        {
            
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
        }

        public async Task CreateClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }


        public bool ClientExists(Guid id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }

        public Task<Client> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}


