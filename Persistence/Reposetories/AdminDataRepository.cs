using Domain.IRepositories.DataRepository;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.DataRepository
{
    public class AdminDataRepository : IAdminDataRepository
    {
        private readonly CorrectAcademyContext _context;

        public AdminDataRepository(CorrectAcademyContext context) => _context = context;


        public int SaveChanges() => _context.SaveChanges();
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
