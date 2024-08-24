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
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(ur => (ICollection<CorrectInstructor>)ur.Instructor)
              .WithMany(u => u.Courses);

               builder.HasMany(ur => ur.Classes)
              .WithOne(u => u.Course);
        }
    }
}
