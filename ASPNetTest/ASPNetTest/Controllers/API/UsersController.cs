using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using ASPNetTest.Models;

namespace ASPNetTest.Controllers.API
{
    public class UsersController : ApiController
    {
	    private ApplicationDbContext _context;

	    public UsersController()
	    {
		    _context = new ApplicationDbContext();
	    }

		// GET /api/users
	    public IHttpActionResult GetUsers()
	    {
		    var users = _context.Users
			    .Include(u => u.MembershipType)
			    .ToList();
			return Ok(users);
	    }

		//GET /api/users/1
		public IHttpActionResult GetUser(int id)
		{
			var user = _context.Users.SingleOrDefault(u => u.Id == id);

			if (user == null)
				return NotFound();

			return Ok(user);
		}

		//POST /api/users
		[HttpPost] //PostUser - тогда можно не использовать аттрибут. Плохо поддерживает рефакторинг
		public IHttpActionResult CreateUser(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			_context.Users.Add(user);
			_context.SaveChanges();

			return Created(new Uri(Request.RequestUri + "/" + user.Id), user);
		}

		//PUT /api/users/1
		[HttpPut]
		public void UpdateUser(int id, User user)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

			if(userInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			userInDb.Name = user.Name;
			userInDb.DateOfBirthDay = user.DateOfBirthDay;
			userInDb.IsSubscribedToNewsletter = user.IsSubscribedToNewsletter;
			userInDb.MembershipTypeId = user.MembershipTypeId;

			_context.SaveChanges();
		}

		//DELETE /api/users/1
		[HttpDelete]
		public void DeleteUser(int id)
		{
			var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

			if (userInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Users.Remove(userInDb);
			_context.SaveChanges();
		}
    }
}
