﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInquiry.Model
{
    public class Inquiry
    {
        public Guid Id { get; set; }
        public Guid client_id { get; set; }
        public string department_address { get; set; }
        public decimal amout { get; set; }
        public string UAN { get; set; }
        public int status { get; set; }
    }
}
