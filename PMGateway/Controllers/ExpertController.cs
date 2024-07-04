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
    }
}
