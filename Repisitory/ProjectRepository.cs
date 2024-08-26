using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repisitory
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TechtrendsContext context) : base(context)
        {

        }
        public IEnumerable<Project>GetAll()
        {
            return _context.Projects.ToList();
        }
        public Project GetProject()
        {
            return _context.Projects.OrderByDescending(p => p.ProjectCreationDate).FirstOrDefault();
        }
        public async Task<Project> GetProjectByIdAsync(Guid? id)
        {

            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }


        public bool ProjectExists(Guid id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }


    }
}
