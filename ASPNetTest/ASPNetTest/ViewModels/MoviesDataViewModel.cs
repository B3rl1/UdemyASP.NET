using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNetTest.Models;

namespace ASPNetTest.ViewModels
{
	public class MoviesDataViewModel
	{
		public Movie Movie { get; set; }
		public List<GenreType> GenreTypes { get; set; }
	}
}