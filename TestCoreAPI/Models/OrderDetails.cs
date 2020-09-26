using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id{ get; set; }
        /// <summary>
        /// Номер заказа
        /// </summary>
        public int OrderId{ get; set; }
        /// <summary>
        /// Номер продукта
        /// </summary>
        public int ProductId{ get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime SetDate { get; set; }
        /// <summary>
        /// Кол-во
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        private decimal total { get; set; }

        public decimal Total {
            get
            {
                return total;
            }
            set
            {
                total = Qty * Price;
            }
        }

        /// <summary>
        /// Заказ
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }
    }
}
