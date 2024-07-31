using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceFile;
using ServiceMetier;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
       ServiceMetier.Service1Client service= new ServiceMetier.Service1Client();

        [HttpPost]
        public bool AddExpert(ServiceMetier.Expert expert) { 
            return service.AddExpert(expert);
        }
        [HttpGet]
        public async Task<ICollection<ServiceMetier.Expert>> GetExperts()
        {
            return await service.GetAllExpertAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceMetier.Expert>> GetExpert(int id)
        {
            var expert = await service.GetExpertAsync(id);
            if (expert == null)
            {
                return NotFound();
            }
            return expert;
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateExpert(int id, ServiceMetier.Expert expert)
        //{
        //    if (id != expert.Id)
        //    {
        //        return BadRequest("Expert ID mismatch");
        //    }

        //    var result = await service.UpdateExpertAsync(expert);
        //    if (result)
        //    {
        //        return NoContent(); // Success but no content to return
        //    }
        //    return NotFound("Expert not found");
        //}
        [HttpPut("{id}")]
        public ActionResult UpdateExpert(int id, ServiceMetier.Expert expert) 
        {
            var existingExpert = service.GetExpert(id);
            if (existingExpert == null)
            {
                return NotFound();
            }

            expert.Id = id;
            var result = service.UpdateExpert(expert); 

            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la mise à jour de l'expert");
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpert(int id)
        {
            var result = await service.DeleteExpertAsync(id);
            if (result)
            {
                return NoContent(); // Success but no content to return
            }
            return NotFound("Expert not found");
        }

    }
}
