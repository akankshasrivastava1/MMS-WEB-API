using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMS.Data;
using MMS.Models;

namespace MMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbConnect _context;
        public MoviesController(MoviesDbConnect moviesDbConnect)
        {
            _context = moviesDbConnect;
        }

        [HttpPost("add_movies")]
        public IActionResult AddMovies([FromBody] Movies moviesObj)
        {
            try
            {
                if (moviesObj == null)
                {
                    return BadRequest();
                }
                else
                {
                    _context.movies.Add(moviesObj);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Messsage = "Movies added Successfully"
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut("update_movies")]
        public IActionResult UpdateMovies([FromBody] Movies moviesObj)
        {
            if (moviesObj == null)
            {
                return BadRequest();
            }
            var user = _context.movies.AsNoTracking().FirstOrDefault(x => x.Id == moviesObj.Id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Not Found"
                });
            }
            else
            {
                _context.Entry(moviesObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Moives Updated Successfully"
                });
            }
        }
        [HttpDelete("delete_movies/{id}")]
        public IActionResult DeleteMovies(int id)
        {
            var user = _context.movies.Find(id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "user not Found"
                });
            }
            else
            {
                _context.Remove(user);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "MoviesAPI Deleted"
                });
            }
        }
        [HttpGet("get_all_movies")]
        public IActionResult GetAllMovies()
        {
            var movies = _context.movies.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                MoviesDetails = movies
            });
        }
        [HttpGet("get_movies")]
        public IActionResult Getmovies(int id)
        {
            var movies = _context.movies.Find(id);
            if (movies == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "movies Not Found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    MoviesDetail = movies
                });
            }
        }

    }
}
