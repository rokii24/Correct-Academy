using Domain.Entities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;

namespace Persistence.Configurations
{
    public class UsersClassConfig : IEntityTypeConfiguration<UsersClass>
    {
        public void Configure(EntityTypeBuilder<UsersClass> builder)
        {
            builder.HasKey(ur => new { ur.InstructorId, ur.StudentId, ur.CourseId });
            builder.HasOne(ur=>(CorrectInstructor)ur.Instructor).WithMany(u=>u.UsersClass).HasForeignKey(u=>u.InstructorId);
            builder.HasOne(ur=>(CorrectStudent)ur.Student).WithMany(u=>u.UsersClasses).HasForeignKey(u=>u.StudentId);
            builder.HasOne(ur=> ur.Course).WithMany(u=>u.UsersClasses).HasForeignKey(u=>u.CourseId);
        }
    }
}
