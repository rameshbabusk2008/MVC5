using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Stock Must be between 1 to 20")]
        public int? NumberinStock { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie Movie)
        {
            Id = Movie.Id;
            Name = Movie.Name;
            NumberinStock = Movie.NumberinStock;
            DateAdded = Movie.DateAdded;
            ReleaseDate = Movie.ReleaseDate;
            GenreId = Movie.GenreId;
        }
        public string Title
        {

            get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }

            
        }
    }
}