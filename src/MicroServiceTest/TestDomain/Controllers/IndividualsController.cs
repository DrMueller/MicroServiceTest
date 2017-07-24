using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.MicroServiceTest.TestDomain.Models;
using Mmu.MicroServiceTest.TestDomain.Services;

namespace Mmu.MicroServiceTest.TestDomain.Controllers
{
    [Route("api/[controller]")]
    public class IndividualsController : Controller
    {
        private readonly IIndividualService _individualService;

        public IndividualsController(IIndividualService individualService)
        {
            _individualService = individualService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndividualAsync([FromBody] Individual individual)
        {
            var createdIndividual = await _individualService.CreateIndividualAsync(individual);
            return Ok(createdIndividual);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndividualsAsync()
        {
            var allIndividuals = await _individualService.GetAllAsync();
            return Ok(allIndividuals);
        }
    }
}