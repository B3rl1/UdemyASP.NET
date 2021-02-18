using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ASPNetTest.Models;

namespace ASPNetTest.ViewModels
{
	public class MoviesDataViewModel
	{
		public int? Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte? GenreTypeId { get; set; }

		[Required]
		[Range(1, 20)]
		[Display(Name = "Number In Stock")]
		public int? NumberInStock { get; set; }

		public List<GenreType> GenreTypes { get; set; }

		public string Title
		{
			get
			{
				if (Id != 0)
					return "Edit Movie";
				return "New Movie";
			}
		}

		public MoviesDataViewModel()
		{

		}

		public MoviesDataViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			GenreTypeId = movie.GenreTypeId;
			NumberInStock = movie.NumberInStock;
		}
	}
}