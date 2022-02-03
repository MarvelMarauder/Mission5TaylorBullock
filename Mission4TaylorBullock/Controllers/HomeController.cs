using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4TaylorBullock.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4TaylorBullock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Category = blahContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
            blahContext.Add(mr);
            blahContext.SaveChanges();

            return View("Confirmation", mr);
            }
            else //if invalid, send back to the form and see error messages
            {
                ViewBag.Category = blahContext.Categories.ToList();
                return View(mr);
            }

        }

        public IActionResult MovieList()
        {
            var movies = blahContext.Response
                .Include(x => x.Category)
                .OrderBy(i => i.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Category = blahContext.Categories.ToList();

            var movie = blahContext.Response.Single(x => x.MovieID == movieid);

            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse edited_movie)
        {
            blahContext.Update(edited_movie);
            blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var to_delete = blahContext.Response.Single(x => x.MovieID == movieid);

            return View(to_delete);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mv)
        {
            blahContext.Response.Remove(mv);
            blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        public IActionResult Podcasts()
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
