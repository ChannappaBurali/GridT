﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridTask.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }
    }
}