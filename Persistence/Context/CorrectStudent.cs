﻿using Domain.Entities.AuthenticationEntities;
using Domain.Entities.DataEntities;
using Domain.Enums;


namespace Persistence.Context
{
    public class CorrectStudent : CorrectUser, IStudent
    {

        public int Age { get; set; }
        public Gender Gender { get; set; } 
        public string? BackgroundImage { get; set; }
        public ICollection<Certificate>? Certificates { get; set; }
        public ICollection<Course> Courses { get; set; } = null!;
        public ICollection<StudentExam> StudentExams { get; set; } = null!;
        public ICollection<UsersClass>? UsersClasses { get ; set; }
        public ICollection<Class>? Classes { get ; set; }
    }
}
