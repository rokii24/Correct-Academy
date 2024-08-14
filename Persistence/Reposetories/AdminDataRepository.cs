using Domain.IReposetories.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reposetories.DataRepository
{
    public class AdminDataRepository : IAdminDataRepository
    {
       // private readonly CorrectContext _context;

      

       // public AdminDataRepository(CorrectContext correctContext) =>_context = correctContext;
      
        public Task<IEnumerable<object>> GetDevicesRequiringUpdate(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges() => throw new NotImplementedException();

    }
}
