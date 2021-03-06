﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetTest.Models;
using ASPNetTest.ViewModels;

namespace ASPNetTest.Controllers
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

        // GET: Movies
        public ActionResult Index()
        {
	        if (User.IsInRole(RoleName.CanManageMovies))
	        {
		        return View("List");
	        }
	        else
	        {
		        return View("ReadOnlyList");
	        }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int id)
        {
	        var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == id);

	        if (movie == null)
		        return HttpNotFound();

	        var modelView = new MoviesDataViewModel(movie)
	        {
		        GenreTypes = _context.GenreTypes.ToList()
	        };

			return View("MoviesForm", modelView);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Save(Movie movie)
        {
	        if (!ModelState.IsValid)
	        {
		        var modelView = new MoviesDataViewModel(movie)
		        {
			        GenreTypes = _context.GenreTypes.ToList()
		        };
	        }

	        if (movie.Id == 0)
		        _context.Movies.Add(movie);
	        else
	        {
		        var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

		        movieInDb.Name = movie.Name;
		        movieInDb.ReleaseDate = movie.ReleaseDate;
		        movieInDb.GenreTypeId = movie.GenreTypeId;
		        movieInDb.NumberInStock = movie.NumberInStock;
	        }

			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				Console.WriteLine(e);
			}

	        return RedirectToAction("Index", "Movies");
        }

		[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
	        var genres = _context.GenreTypes.ToList();

	        var modelView = new MoviesDataViewModel()
	        {
		        GenreTypes = genres
	        };

	        return View("MoviesForm", modelView);
        }
    }
}