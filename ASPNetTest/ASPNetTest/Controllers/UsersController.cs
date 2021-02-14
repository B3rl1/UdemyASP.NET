using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using ASPNetTest.Models;
using ASPNetTest.ViewModels;

namespace ASPNetTest.Controllers
{
    public class UsersController : Controller
    {
	    private ApplicationDbContext _context; //Название по соглашениям.

	    public UsersController()
	    {
			_context = new ApplicationDbContext();
	    }

	    protected override void Dispose(bool disposing)
	    {
		    _context.Dispose();
	    }

	    // GET: Users
        public ActionResult Index()
        {
	        var users = _context.Users.Include(u => u.MembershipType).ToList();//Eager Loading, поскольку EF по стандарту не загружает внешние данные связанные с текущим объектом

			var model = new IndexUsersViewModel();
			model.Users = users.ToList();

	        return View(model);
        }

        public ActionResult New()
        {
	        var membershipTypes = _context.MembershipTypes.ToList();

	        var modelView = new CustomerDataViewModel()
	        {
		        MembershipType = membershipTypes
	        };

	        return View("CustomerForm", modelView);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
	        if (user.Id == 0)
		        _context.Users.Add(user);
	        else
	        {
		        var customerInDb = _context.Users.Single(u => u.Id == user.Id);

		        customerInDb.Name = user.Name;
		        customerInDb.DateOfBirthDay = user.DateOfBirthDay;
		        customerInDb.MembershipTypeId = user.MembershipTypeId;
		        customerInDb.IsSubscribedToNewsletter = user.IsSubscribedToNewsletter;


		        //Открывает новые дыры в защите
		        //TryUpdateModel(customerInDb, "", new string[] {"Name", "Email"});//Обновление только Name и Email. Проблема в том, что если изменить названия свойств,
		        //а здесь забыть, то программа не будет работать


	        }
			_context.SaveChanges();

	        return RedirectToAction("Index","Users");
        }

        public ActionResult AboutUser(int id)
        {
	        var user = _context.Users.Include(u => u.MembershipType).SingleOrDefault(us => us.Id == id);

	        if (user == null)
		        return HttpNotFound();
	        return View(user);
        }

        public ActionResult Edit(int id)
        {
	        var user = _context.Users.Include(u => u.MembershipType).SingleOrDefault(u => u.Id == id);

	        if (user == null)
		        return HttpNotFound();

	        var viewModel = new CustomerDataViewModel()
	        {
		        User = user,
		        MembershipType = _context.MembershipTypes.ToList()
	        };
	        return View("CustomerForm", viewModel);
        }
    }
}