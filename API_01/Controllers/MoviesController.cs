using API_01.DAL.Models.Dtos.Movie;
using API_01.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id:int}", Name = "GetMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost(Name = "CreateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync(
            [FromBody] MovieCreateUpdateDto movieCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdMovie = await _movieService.CreateMovieAsync(movieCreateDto);

                return CreatedAtRoute("GetMovieAsync",
                    new { id = createdMovie.Id }, createdMovie);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieDto>> UpdateMovieAsync(
            int id,
            [FromBody] MovieCreateUpdateDto movieUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedMovie = await _movieService.UpdateMovieAsync(id, movieUpdateDto);

                if (updatedMovie is null)
                    return NotFound();

                return Ok(updatedMovie);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteMovieAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                var deleted = await _movieService.DeleteMovieAsync(id);

                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

