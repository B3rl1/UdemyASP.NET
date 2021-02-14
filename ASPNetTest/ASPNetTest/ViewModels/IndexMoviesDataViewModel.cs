using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNetTest.Models;

namespace ASPNetTest.ViewModels
{
	public class IndexMoviesDataViewModel
	{
		public List<Movie> Movie { get; set; }
		public List<GenreType> GenreType { get; set; }
	}
}