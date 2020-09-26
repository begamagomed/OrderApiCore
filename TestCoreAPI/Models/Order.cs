using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        [ForeignKey("Status")]
        public int StatusId{ get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime? SetDate { get; set; }
        /// <summary>
        /// Справочник статусов
        /// </summary>
        public OrderStatus Status { get; set; }
    }
}
