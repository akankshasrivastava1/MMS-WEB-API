using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMS.Data;
using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace MMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly MoviesDbConnect _context;
        public SearchController(MoviesDbConnect moviesDbConnect)
        {
            _context = moviesDbConnect;
        }
        
       

        [HttpGet("{id}")]
        public Movies Search(int id)
        {
            Movies obj = _context.movies.Find(id);
            return obj;
        }
    }
}
