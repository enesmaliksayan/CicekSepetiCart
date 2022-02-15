using CicekSepetiCart.Application.Models.Enums;
using System;

namespace CicekSepetiCart.Application.Models
{
    public class CartItemModel : BaseModel
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public CartStatus Status { get; set; }
    }
}
