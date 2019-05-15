using System;
using System.Collections.Generic;

namespace AddToCart.Entities
{
    public static class MovieContextExtensions
    {
        public static void EnsureSeedDataForContext(this AddToCartContext context)
        {
            context.Categories.RemoveRange(context.Categories);
            context.Movies.RemoveRange(context.Movies);
            context.Directors.RemoveRange(context.Directors);
            context.SaveChanges();

            var recipes = new List<Movie>()
            {
                new Movie()
                {
                    MovieId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Title = "Avengers: Endgame",
                    Description = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to undo Thanos' actions and restore order to the universe.",
                    Price = 57.90,
                    StockCount = 50,
                    MovieCategories = new List<MovieCategory>()
                    {
                        new MovieCategory()
                        {
                            Category = new Category()
                            {
                                CategoryId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                                Name = "Fantastic"
                            }
                        },
                        new MovieCategory()
                        {
                            Category = new Category()
                            {
                                CategoryId = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                                Name = "Science Fiction"
                            }
                        }
                    },
                    Director = new Director()
                    {
                        Id = new Guid("5b702a5c-557b-4de3-8fa1-bb82187b12f6"),
                        FirstName = "Anthony",
                        LastName = "Russo"
                    }
                }
            };

            context.Movies.AddRange(recipes);
            context.SaveChanges();
        }
    }
}
