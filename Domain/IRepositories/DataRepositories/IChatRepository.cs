﻿using Domain.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.DataRepositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<string>> GetAllAsync();
        Task<Chat> GetByIdAsync(Chat id);
        Task AddAsync(Chat entity);
        Task UpdateAsync(Chat entity);
        Task DeleteAsync(string id);
    }
}
