using AddToCart.Entities;
using System;
using System.Collections.Generic;

namespace AddToCart.Services
{
    interface IAddToCartRepository
    {
        User GetUser(Guid Id);
        Movie GetMovie(Guid MovieId);
        Category GetCategory(String categoryName);
        bool MovieExist(String movieTitle);
        void AddMovie(Movie movie);
        void AddCartItem(CartItem cartItem);
        IEnumerable<Movie> GetMovies();
        IEnumerable<Category> GetCategories();
        bool Save();
    }
}
