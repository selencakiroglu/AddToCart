using System;
using System.Collections.Generic;

namespace AddToCart.Entities
{
    public static class UserContextExtensions
    {
        public static void EnsureSeedDataForUserContext(this AddToCartContext context)
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            var users = new List<User>()
            {
                new User()
                {
                    Id = new Guid("91a1f42b-b25f-4ea0-ae60-6dc51680b173"),
                    Name = "Selen",
                    CartItems = new List<CartItem>()
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
