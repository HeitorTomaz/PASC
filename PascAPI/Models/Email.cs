﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Models
{
    public class Email
    {
        public int EmailId { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
