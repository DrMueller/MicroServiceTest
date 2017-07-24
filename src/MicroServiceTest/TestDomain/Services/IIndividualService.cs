using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.MicroServiceTest.TestDomain.Models;

namespace Mmu.MicroServiceTest.TestDomain.Services
{
    public interface IIndividualService
    {
        Task<Individual> CreateIndividualAsync(Individual individual);

        Task<IReadOnlyCollection<Individual>> GetAllAsync();

        Task<Individual> GetOneAsync();
    }
}