﻿using Domain.Entities.AuthonticationEntity;
using Domain.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AuthenticationEntities
{
    public interface IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? OTP { get; set; }
        public string? UserImage { get; set; }
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public DateTime? OTPValidTo { get; set; }
        DateTime RegistrationTime { get; set; }
        public string RoleId { get; set; } 
        public IRole Role { get; set; }
        public ICollection<Post>? Posts { get; set; } 
        public ICollection<Message>? Messages { get; set; } 

    }
}
