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
    public class CertificateConfig : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(ur => (CorrectStudent)ur.Student)
              .WithMany(u => u.Certificates)
              .HasForeignKey(ur => ur.StudentId);

        }
    }
}
