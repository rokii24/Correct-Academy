﻿using Domain.Entities.AuthenticationEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataEntities
{
    public class Chat 
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public Class Class { get; set; } = null!;
        public ICollection<Message>? Messages { get; set;}
    }
}
