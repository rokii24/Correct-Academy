//using Domain.Entities.DataEntities;
//using Domain.IRepositories.DataRepositories;
//using Google;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Persistence.Reposetories.DAtaReposatoiry.CertificateReposatiory;

//namespace Persistence.Reposetories.DAtaReposatoiry
//{
//    public class CertificateReposatiory: ICertificateRepository
//    {
//            private readonly ApplicationDbContext _context;

//            public CertificateReposatiory(ApplicationDbContext context)
//            {
//                _context = context;
//            }

//            public async Task<Certificate> GetByIdAsync(string id)
//            {
//                return await _context.Certificates
//                    .Include(c => c.Student)
//                    .FirstOrDefaultAsync(c => c.Id == id);
//            }

//            public async Task<IEnumerable<Certificate>> GetAllAsync()
//            {
//                return await _context.Certificates
//                    .Include(c => c.Student) // Assuming you want to include the related Student entity
//                    .ToListAsync();
//            }

//            public async Task AddAsync(Certificate certificate)
//            {
//                await _context.Certificates.AddAsync(certificate);
//                await _context.SaveChangesAsync();
//            }

//            public async Task UpdateAsync(Certificate certificate)
//            {
//                _context.Certificates.Update(certificate);
//                await _context.SaveChangesAsync();
//            }

//            public async Task DeleteAsync(string id)
//            {
//                var certificate = await _context.Certificates.FindAsync(id);
//                if (certificate != null)
//                {
//                    _context.Certificates.Remove(certificate);
//                    await _context.SaveChangesAsync();
//                }
//            }
//        }

//    }

