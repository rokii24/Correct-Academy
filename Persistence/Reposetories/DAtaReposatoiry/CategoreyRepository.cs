using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reposetories.DAtaReposatoiry
{
    public class CategoreyRepository : ICategoryReposatiory
    {

        public readonly CorrectAcademyContext _context;
        public readonly DbSet<Category> _dbSet;

        public CategoreyRepository(CorrectAcademyContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();

        }

        public async Task<ICollection<Category>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Category> Get(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(Category entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public  async Task<ICollection<Category>> FilterBy(Func<Category, bool> filter)
        {
            return await Task.Run(() => _dbSet.Where(filter).ToList());
        }

        
    }
}
