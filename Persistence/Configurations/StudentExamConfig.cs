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
    public class StudentExamConfig : IEntityTypeConfiguration<StudentExam>
    {
        public void Configure(EntityTypeBuilder<StudentExam> builder)
        {
            builder.HasKey(e => new { e.StudentId , e.ExamId});

            builder.HasOne(ur => (CorrectStudent)ur.Student)
              .WithMany(u => u.StudentExams)
              .HasForeignKey(ur => ur.StudentId);

        }
    }
    public class ExamConfig : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(ur => (CorrectInstructor)ur.Instructor)
              .WithMany(u => u.Exams)
              .HasForeignKey(ur => ur.InstructorId);

        }
    }
}
