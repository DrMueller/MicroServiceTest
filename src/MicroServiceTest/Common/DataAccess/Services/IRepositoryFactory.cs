using Mmu.MicroServiceTest.Common.Models;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services
{
    public interface IRepositoryFactory
    {
        IRepository<TModel> CreateRepository<TModel>()
            where TModel : EntityBase, new();
    }
}