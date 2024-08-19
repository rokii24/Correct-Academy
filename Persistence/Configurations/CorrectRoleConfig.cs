using Domain.Entities.DataEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CorrectRoleConfig : IEntityTypeConfiguration<CorrectRole>
    {
        public void Configure(EntityTypeBuilder<CorrectRole> builder)
        {
            builder.HasMany(ur => ( ICollection<CorrectUser> )ur.User).WithOne(u => (CorrectRole)u.Role);
        }
    }
}
