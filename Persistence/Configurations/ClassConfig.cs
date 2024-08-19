using Domain.Entities.DataEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(e => e.Id);

            
            builder.HasOne(cl => cl.Chat)
                .WithOne(ch => ch.Class)
                .HasForeignKey<Class>(cl => cl.ChatId); 
        }
    }
}
