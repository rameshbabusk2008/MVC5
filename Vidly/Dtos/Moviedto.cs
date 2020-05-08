﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Stock Must be between 1 to 20")]
        public int NumberinStock { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]        
        public DateTime? ReleaseDate { get; set; }

        [Required]       
        public int GenreId { get; set; }
    }
}