using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddToCart.Entities
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ProductId")]
        public Movie Movie { get; set; }

        public Guid MovieId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Guid UserId { get; set; }
    }
}
