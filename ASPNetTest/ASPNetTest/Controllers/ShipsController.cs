using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetTest.Models;
using ASPNetTest.ViewModels;

namespace ASPNetTest.Controllers
{
    public class ShipsController : Controller
    {
        // GET: Ships
        /*public ActionResult Index(int? pageIndex, string sortBy)
        {
	        if (pageIndex.HasValue)
		        pageIndex = 1;
	        if (String.IsNullOrWhiteSpace(sortBy))
		        sortBy = "Name";

	        var users = new List<User>
	        {
                
	        };

	        var viewModel = new IndexUsersViewModel()
	        {
		        Users = users
	        };
	        return View(viewModel);


            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name"});

            //ViewData["Ship"] = ship;
            //ViewBag.Ship = ship;
        }*/

        public ActionResult Edit(int id)
        {
	        return Content("id="+id);
        }

        [Route("ships/name/{name}")]
        public ActionResult ByName(string name)
        {
	        return Content("name="+name);
        }
    }
}