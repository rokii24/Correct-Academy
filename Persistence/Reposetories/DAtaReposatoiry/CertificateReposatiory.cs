
using Domain.Entities.DataEntities;
using Domain.IReposetories.DataRepository;
using Domain.IRepositories.DataRepositories;
using Google;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Persistence.Reposetories.DataReposatoiry.CertificateReposatiory;

namespace Persistence.Reposetories.DataReposatoiry
{
    public class CertificateReposatiory : ICertificateRepository
    {
        public readonly CorrectAcademyContext _context;
        public CertificateReposatiory(CorrectAcademyContext context)
        {
            _context = context;
        }
        public async Task<Certificate> Get(Guid id)
        {
            return await _context.Set<Certificate>().FindAsync(id);
        }

        //public async Task<IEnumerable<Certificate>> GetAll()
        //{
        //    return await _context.Set<Certificate>().ToListAsync();
        //}

        public async Task Add(Certificate certificate)
        {
            await _context.Set<Certificate>().AddAsync(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Certificate certificate)
        {
            _context.Set<Certificate>().Update(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Certificate entity)
        {
            var certificate = await Get(entity.Id);
            if (certificate != null)
            {
                _context.Set<Certificate>().Remove(certificate);
                await _context.SaveChangesAsync();
            }
        }

        async Task<ICollection<Certificate>> IBaseRepository<Certificate>.GetAll()
        {
            return await _context.Set<Certificate>().ToListAsync();
        }

       

        public Task<ICollection<Certificate>> FilterBy(Func<Certificate, bool> filter)
        {
            throw new NotImplementedException();
        }
    }







}



























  