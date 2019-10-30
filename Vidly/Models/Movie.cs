using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }   
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Number In Stock")]
        [MoviesInStockLimits]
        public int NumberInStock { get; set; }
        
        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Required]
        [Display(Name = "Release Dates")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public byte NumberAvailible { get; set; }

    }
}