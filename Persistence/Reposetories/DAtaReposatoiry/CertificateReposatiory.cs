//<<<<<<< HEAD
//﻿//using Domain.Entities.DataEntities;
////using Domain.IRepositories.DataRepositories;
////using Google;
////using Microsoft.EntityFrameworkCore;
////using Persistence.Context;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using static Persistence.Reposetories.DAtaReposatoiry.CertificateReposatiory;

////namespace Persistence.Reposetories.DAtaReposatoiry
////{
////    public class CertificateReposatiory : ICertificateRepository
////    {
////        private readonly CorrectAcademyContext _context;

////        public CertificateReposatiory(CorrectAcademyContext context)
////        {
////            _context = context;
////        }

////        public async Task<Certificate> GetByIdAsync(int id)
////        {

using Domain.Entities.DataEntities;
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

        //            private readonly CorrectAcademyContext _context;
        public Task AddAsync(Certificate certificate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Certificate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Certificate> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Certificate certificate)
        {
            throw new NotImplementedException();
        }
    }
}
//    {
//            private readonly CorrectAcademyContext _context;

//            public CertificateReposatiory(CorrectAcademyContext context)
//            {
//                _context = context;
//            }

//            public async Task<Certificate> GetByIdAsync(Guid id)
//            {
//                return await _context.Certificates
//                    .Include(c => c.Student)
//                    .FirstOrDefaultAsync(c => c.Id == id);
//            }

////            return await _context.Certificates
////                .Include(c => c.Student)
////                .FirstOrDefault(c => c.Id == id);
////        }

////        public async Task<IEnumerable<Certificate>> GetAllAsync()
////        {
////            return await _context.Certificates
////                .Include(c => c.Student) // Assuming you want to include the related Student entity
////                .ToListAsync();
////        }

////        public async Task AddAsync(Certificate certificate)
////        {
////            await _context.Certificates.AddAsync(certificate);
////            await _context.SaveChangesAsync();
////        }

////        public async Task UpdateAsync(Certificate certificate)
////        {
////            _context.Certificates.Update(certificate);
////            await _context.SaveChangesAsync();
////        }

////        public async Task DeleteAsync(string id)
////        {
////            var certificate = await _context.Certificates.FindAsync(id);
////            if (certificate != null)
////            {
////                _context.Certificates.Remove(certificate);
////                await _context.SaveChangesAsync();
////            }
////        }
////    }

////}

