using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repisitory
{
    public interface IClientRepository : IGenericRepository<Client>
    {
       
        Task<Client> GetClientByIdAsync(Guid? id);
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
        bool ClientExists(Guid id);
       
       // Client GetAll();



    }
}
