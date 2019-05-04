using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddToCart.Entities
{
    public class MovieCategory
    {
        [Key, Column(Order = 0)]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }

        [Key, Column(Order = 1)]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
