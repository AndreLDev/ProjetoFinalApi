﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Desciption { get; set; }
        public decimal Price { get; set;}
        public int Stock { get; set;}
        public int MinStock { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}
