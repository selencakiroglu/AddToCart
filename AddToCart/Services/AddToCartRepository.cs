using System;
using System.Collections.Generic;
using System.Linq;
using AddToCart.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddToCart.Services
{
    public class AddToCartRepository : IAddToCartRepository
    {
        private AddToCartContext _context;

        public AddToCartRepository(AddToCartContext context)
        {
            _context = context;
        }

        public void AddCartItem(CartItem cartItem)
        {
            if (cartItem.User != null && cartItem.Movie != null)
            {
                if (cartItem.Id == Guid.Empty)
                {
                    cartItem.Id = Guid.NewGuid();
                }
                cartItem.User.CartItems.Add(cartItem);
            }
        }

        public void AddMovie(Movie movie)
        {
            movie.MovieId = Guid.NewGuid();
            _context.Movies.Add(movie);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(category => category.Name).ToList();
        }

        public Category GetCategory(string categoryName)
        {
            return _context.Categories.FirstOrDefault(category => category.Name.Trim().ToLowerInvariant() == categoryName.Trim().ToLowerInvariant());
        }

        public Movie GetMovie(Guid MovieId)
        {
            return _context.Movies.FirstOrDefault(movie => movie.MovieId == MovieId);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(movie => movie.Title).ToList();
        }

        public User GetUser(Guid userId)
        {
            return _context.Users.Include(user => user.CartItems)
                .ThenInclude(cartItem => cartItem.Movie)
                .FirstOrDefault(user => user.Id == userId);
        }

        public bool MovieExist(string movieTitle)
        {
            return _context.Movies.Any(movie => movie.Title.Trim().ToLowerInvariant() == movieTitle.Trim().ToLowerInvariant());
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
