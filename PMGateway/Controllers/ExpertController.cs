using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http;
using ServiceMetier;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ServiceMetier.Service1Client _service;

        public ExpertController(IHttpClientFactory httpClientFactory, ServiceMetier.Service1Client service)
        {
            _httpClientFactory = httpClientFactory;
            _service = service;
        }

        [HttpPost]
        public ActionResult<bool> AddExpert(ServiceMetier.Expert expert)
        {
            // Exemple d'utilisation de service métier existant
            bool result = _service.AddExpert(expert);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ServiceMetier.Expert>>> GetExperts()
        {
            // Utilisation de HttpClient pour appeler un service externe (exemple)
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7057/api/Expert");

            if (response.IsSuccessStatusCode)
            {
                var experts = await response.Content.ReadAsAsync<ICollection<ServiceMetier.Expert>>();
                return Ok(experts);
            }
            else
            {
                return StatusCode((int)response.StatusCode, $"Failed to retrieve experts. Status code: {response.StatusCode}");
            }
        }
    }
}
