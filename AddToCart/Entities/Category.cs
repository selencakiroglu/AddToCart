using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddToCart.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public ICollection<MovieCategory> MovieCategories { get; set; }
            = new List<MovieCategory>();
    }
}
