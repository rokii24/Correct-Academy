﻿using Domain.Entities.AuthenticationEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CorrectInstractor : CorrectUser
    {
        public string? Salary { get; set; }
    }
}
