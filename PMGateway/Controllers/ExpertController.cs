using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceFile;
using ServiceMetier;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpDelete("{id}")]
        public async Task<bool> DeleteExpert(int id)
        {
            return await service.DeleteExpertAsync(id);
        }
        [HttpPut("{id}")]
        public async Task<bool> UpdateExpert(int id, [FromBody] ServiceMetier.Expert expert)
        {
            expert.Id = id; // Assurez-vous que l'ID de l'expert à mettre à jour est correct
            return await service.UpdateExpertAsync(expert);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceMetier.Expert>> GetExpert(int id)
        {
            try
            {
                ServiceMetier.Expert expert = await service.GetExpertAsync(id);
                if (expert == null)
                {
                    return NotFound("Expert non trouvé.");
                }
                return Ok(expert);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
