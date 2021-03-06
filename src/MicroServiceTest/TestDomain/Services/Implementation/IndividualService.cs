﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.MicroServiceTest.Common.DataAccess.Services;
using Mmu.MicroServiceTest.TestDomain.Models;

namespace Mmu.MicroServiceTest.TestDomain.Services.Implementation
{
    public class IndividualService : IIndividualService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public IndividualService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Individual> CreateIndividualAsync(Individual individual)
        {
            var individualRepo = _repositoryFactory.CreateRepository<Individual>();
            var result = await individualRepo.SaveAsync(individual);

            return result;
        }

        public async Task<IReadOnlyCollection<Individual>> GetAllAsync()
        {
            var individualRepo = _repositoryFactory.CreateRepository<Individual>();
            var result = await individualRepo.LoadAllAsync();

            return result;
        }

        public async Task<Individual> GetOneAsync()
        {
            var individualRepo = _repositoryFactory.CreateRepository<Individual>();
            var allIndividuals = await individualRepo.LoadAllAsync();

            var result = allIndividuals.FirstOrDefault();
            return result;
        }
    }
}