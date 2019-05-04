using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddToCart.Entities
{
    public class Movie
    {
        [Key]
        public Guid MovieId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public ICollection<MovieCategory> MovieCategories { get; set; }
            = new List<MovieCategory>();
        
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }

        public Guid DirectorId { get; set; }               
    }
}
