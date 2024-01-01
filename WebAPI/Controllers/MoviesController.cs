using Business.Abstracts;
using Entity.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieRequest addMovieRequest)
        {
            var result = await _movieService.Add(addMovieRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMovieRequest updateMovieRequest)
        {
            var result = await _movieService.Update(updateMovieRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> Delete([FromRoute] int movieId)
        {
            var result = await _movieService.Delete(movieId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _movieService.GetList();

            return result.Success ? Ok(result) : BadRequest();
        }


        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieById([FromRoute] int movieId)
        {
            var result = await _movieService.GetMovieById(movieId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
