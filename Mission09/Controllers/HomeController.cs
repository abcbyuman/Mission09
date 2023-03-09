using Microsoft.AspNetCore.Mvc;
using Mission09.Models;
using Mission09.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                .Where(p => p.Category == category || category == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = (category == null 
                    ? repo.Projects.Count() 
                    : repo.Projects.Where(x => x.Category == category).Count()),
                    ProjectPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        //This line below is the exact same as what is above
        //public IActionResult Index() => View();
    }
}
