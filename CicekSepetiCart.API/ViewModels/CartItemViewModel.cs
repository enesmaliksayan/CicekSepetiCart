using CicekSepetiCart.API.ViewModels.Enums;
using System;

namespace CicekSepetiCart.API.ViewModels
{
    public class CartItemViewModel : BaseModel
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public CartStatusViewModel Status { get; set; }

        public CartItemViewModel()
        {
            Id ??= Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
