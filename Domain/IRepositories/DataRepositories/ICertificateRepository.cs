using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.DataRepositories
{
    public interface ICertificateRepository 
    {

        Task<Certificate> GetByIdAsync(int id);
        Task<Certificate> GetByIdAsync(Guid id);
        Task<IEnumerable<Certificate>> GetAllAsync();
        Task AddAsync(Certificate certificate);
        Task UpdateAsync(Certificate certificate);
        Task DeleteAsync(string id);

        


    }
}