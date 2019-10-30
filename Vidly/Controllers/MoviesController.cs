using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //List<Movie> Movies = new List<Movie>()
        //{
        //    new Movie(){ Id=1, Name="Film1", DateAdded = Convert.ToDateTime("01/01/1901"), ReleaseDate =  Convert.ToDateTime("01/01/1901"), NumberInStock = 1},
        //    new Movie(){ Id=2, Name="Film2", DateAdded = Convert.ToDateTime("01/01/1911"), ReleaseDate =  Convert.ToDateTime("01/01/1911"), NumberInStock = 2},
        //    new Movie(){ Id=3, Name="Film3", DateAdded = Convert.ToDateTime("01/01/1921"), ReleaseDate =  Convert.ToDateTime("01/01/1921"), NumberInStock = 3}
        //};

        // GET: Movies
        public ActionResult Index()
        {
            //var MoviesViewModel = new MovieViewModel()
            //{
            //    Movies = _context.Movies.Include(m => m.Genre).ToList()
            //};

            //return View(MoviesViewModel);

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("MovieList");
            }
            
            return View("ReadOnlyMovies");  
        }

        public ActionResult ReadOnly(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = movie.Name;

            var ViewModel = new MovieViewModel()
            {
                Movie = movie
            };

            return View(ViewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {
            ViewBag.Title = "New Movie";

            var ViewModel = new MovieFormViewModel()
            { 
                Genres = _context.Genres.ToList(),
                Movie = new Movie()
            };

            return View("MovieForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Title = "Please Retry";

                var ViewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", ViewModel);
            }

            if (movie.Id == 0)
            {
                //only add to membory not to db
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }

            //update sql db
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            ViewBag.Title = "Edit Customer";

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {

                var ViewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", ViewModel);
            }

        }


    }
}