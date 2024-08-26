using TelemetryPortal_MVC.Models;
namespace TelemetryPortal_MVC.Repisitory
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Project GetProject();
        Task<Project> GetProjectByIdAsync(Guid? id);
        Task CreateProjectAsync(Project client);
        Task UpdateProjectAsync(Project client);
        Task DeleteProjectAsync(Guid id);
        bool ProjectExists(Guid id);
        
    }
}
