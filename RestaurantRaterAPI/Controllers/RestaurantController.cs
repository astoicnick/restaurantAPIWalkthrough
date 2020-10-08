﻿using RestaurantRaterAPI.Models;
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
        // Return all restaurants in the database
        [HttpGet]
        public IHttpActionResult Index()
        {
            List<Restaurant> restaurantsInDB = _context.Restaurants.ToList();

            return Ok(restaurantsInDB);
        }
    }
}