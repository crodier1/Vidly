using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.Api
{    
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == newRental.CustomerId);

            if (customer == null)
            {
                return BadRequest("Invalid Customer Id");
            }

            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids Have been given.");
            }

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or move MovieIds are invalid");
            }
           

            foreach (var i in movies)
            {
                if (i.NumberAvailible == 0)
                {
                    return BadRequest("Movie is not availible");
                }

                i.NumberAvailible--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = i,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();


        }
    }
}
