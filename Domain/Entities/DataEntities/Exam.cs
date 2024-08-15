using Domain.Entities.AuthenticationEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Exam : BaseEntity
    {
        /// <summary>
        /// Id is URL
        /// </summary>        
        public new string Id { get; set; } = null!;
        public int Degree { get; set; }

        public ExamType Type { get; set; }
        public string InstructorId { get; set; } = null!;
        public IInstructor Instructor { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public ICollection<StudentExam> StudentExams { get; set; } = null!;
    }

    public class StudentExam
    {
        public string StudentId { get; set; } = null!;
        public IStudent Student { get; set; } = null!;

        public string ExamId { get; set; } = null!;
        public Exam Exam { get; set; } = null!;
        public float ResultDegree { get; set; }

        public string? AnswerUrl {  get; set; }  
    }
}
