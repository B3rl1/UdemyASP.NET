using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNetTest.Models
{
	public class Movie
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Display(Name = "Genre")]
		public GenreType GenreType { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte GenreTypeId { get; set; }

		[Required]
		[Range(1,20)]
		[Display(Name = "Number In Stock")]
		public int NumberInStock { get; set; }

	}
}