using Mmu.MicroServiceTest.Common.Models;
using StructureMap;

namespace Mmu.MicroServiceTest.Common.DataAccess.Services.Implementation
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IContainer _container;

        public RepositoryFactory(IContainer container)
        {
            _container = container;
        }

        public IRepository<TModel> CreateRepository<TModel>() where TModel : EntityBase, new()
        {
            var result = _container.GetInstance<IRepository<TModel>>();
            return result;
        }
    }
}