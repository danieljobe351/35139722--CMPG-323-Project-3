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
    public class ProjectsController : Controller
    {

        private readonly IProjectRepository _projectRepository;

        public ProjectsController(TechtrendsContext context, IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var results = _projectRepository.GetAll();
            return View(results);
        }
        public IActionResult Details()
        {
            return View();
        }

        // GET: Projects/Details/5
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }


        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectDescription,ProjectCreationDate,ProjectStatus,ClientId")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.ProjectId = Guid.NewGuid();
                _projectRepository.Add(project);

                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProjectId,ProjectName,ProjectDescription,ProjectCreationDate,ProjectStatus,ClientId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _projectRepository.Update(project);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            await _projectRepository.DeleteProjectAsync(id);

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project != null)
            {
                _projectRepository.Remove(project);
            }


            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(Guid id)
        {

            return _projectRepository.ProjectExists(id);
        }
    }
}