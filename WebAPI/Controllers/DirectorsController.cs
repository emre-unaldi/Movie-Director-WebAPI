using Business.Abstracts;
using Entity.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDirectorRequest addDirectorRequest)
        {
            var result = await _directorService.Add(addDirectorRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDirectorRequest updateDirectorRequest)
        {
            var result = await _directorService.Update(updateDirectorRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{directorId}")]
        public async Task<IActionResult> Delete([FromRoute] int directorId)
        {
            var result = await _directorService.Delete(directorId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _directorService.GetList();

            return result.Success ? Ok(result) : BadRequest();
        }


        [HttpGet("{directorId}")]
        public async Task<IActionResult> GetDirectorById([FromRoute] int directorId)
        {
            var result = await _directorService.GetDirectorById(directorId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
