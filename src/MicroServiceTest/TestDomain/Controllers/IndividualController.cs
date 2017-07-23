using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.MicroServiceTest.TestDomain.Services;

namespace Mmu.MicroServiceTest.TestDomain.Controllers
{
    [Route("api/[controller]")]
    public class IndividualController : Controller
    {
        private readonly IIndividualService _individualService;

        public IndividualController(IIndividualService individualService)
        {
            _individualService = individualService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndividualAsync()
        {
            var individual = await _individualService.CreateIndividualAsync();
            return Ok(individual);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndividualsAsync()
        {
            var individual = await _individualService.GetAllAsync();
            return Ok(individual);
        }
    }
}