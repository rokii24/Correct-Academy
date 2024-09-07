using Domain.Entities.AuthenticationEntities;
using Domain.Entities.DataEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectAcademyContext : IdentityDbContext<CorrectUser,CorrectRole,string>
    {
        public  CorrectAcademyContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<CorrectStudent> Students { get; set; }
        public DbSet<CorrectAcademy> Academies { get; set; }
        public DbSet<CorrectInstructor> Instructors { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UsersClass> UsersClasses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CorrectAcademyContext).Assembly);
        }
    }
}
