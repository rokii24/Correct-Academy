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
    public class ClassRepoSaitorycs:IClassReposaitory
    {


            public readonly CorrectAcademyContext _context;

            public ClassRepoSaitorycs(CorrectAcademyContext context)
            {
                _context = context;
            }
            public async Task Add(Class entity)
            {
                await _context.Classes.AddAsync(entity);
            }

            public async Task Delete(Class entity)
            {
                var Class = await Get(entity.Id);
                if (Class != null)
                {
                    _context.Set<Class>().Remove(Class);
                    await _context.SaveChangesAsync();
                }
            }

            public Task<ICollection<Class>> FilterBy(Func<Class, bool> filter)
            {
                throw new NotImplementedException();
            }

            public async Task<Class> Get(Guid id)
            {
                return await _context.Set<Class>().FindAsync(id);

                //var post = await _context.Class.FirstOrDefaultAsync(p => p.Id == id);
                //if (post == null)
                //    throw new Exception("Post Not Found");
                //return post;
            }

            public async Task<ICollection<Class>> GetAll()
            {
                var Classs = await _context.Classes.ToListAsync();
                if (Classs == null)
                    throw new Exception("Class Not Found");
                return Classs;
            }

            public async Task Update(Class Class)
            {
                _context.Set<Class>().Update(Class);
                await _context.SaveChangesAsync();
            }
        }
    }
