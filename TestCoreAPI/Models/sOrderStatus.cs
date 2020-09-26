﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id{ get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string Name { get; set; }
    }
}
