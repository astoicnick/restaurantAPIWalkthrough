using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // Read All
        [HttpGet]
        public IHttpActionResult Index()
        {
            List<Restaurant> restaurantsInDB = _context.Restaurants.ToList();

            return Ok(restaurantsInDB);
        }
        // Read single
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetByID(int id)
        {
            Restaurant requestedRestaurant = _context.Restaurants.Find(id);
            if (requestedRestaurant == null)
            {
                return NotFound();
            }
            return Ok(requestedRestaurant);
        }
        // Create
        [HttpPost]
        public IHttpActionResult Create(Restaurant restaurantToAdd)
        {
            _context.Restaurants.Add(restaurantToAdd);

            if (_context.SaveChanges() == 1)
            {
                return Ok(restaurantToAdd);
            }

            return BadRequest();
        }
        // Update
        [HttpPut]
        public IHttpActionResult Update(Restaurant updatedRestaurant)
        {
            Restaurant requestedRestaurant = _context.Restaurants.Find(updatedRestaurant.RestaurantId);
            if (requestedRestaurant == null)
            {
                return BadRequest("Invalid ID");
                //return NotFound();
            }

            requestedRestaurant.Name = updatedRestaurant.Name;
            requestedRestaurant.Rating = updatedRestaurant.Rating;

            if (_context.SaveChanges() == 1)
            {
                return Ok(updatedRestaurant);
            }

            //return InternalServerError();
            return BadRequest();
        }
        // Delete
    }
}
