using System;
using Mmu.MicroServiceTest.Common.Models;

namespace Mmu.MicroServiceTest.TestDomain.Models
{
    public class Individual : EntityBase
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}