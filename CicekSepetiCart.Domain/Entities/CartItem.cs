using CicekSepetiCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public CartStatus Status { get; set; }

        public CartItem()
        {
            Id ??= Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
