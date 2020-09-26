using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Models
{
    public class Product
    {
        [Key]
        public int Id{ get; set; }
        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime SetDate { get; set; }
    }
}
