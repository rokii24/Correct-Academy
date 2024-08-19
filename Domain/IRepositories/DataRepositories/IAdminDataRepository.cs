using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.DataRepository
{
    public interface IAdminDataRepository
    {  
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
