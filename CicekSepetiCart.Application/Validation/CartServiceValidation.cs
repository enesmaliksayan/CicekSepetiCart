using CicekSepetiCart.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Application.Validation
{
    public class CartServiceValidation
    {
        public static void IsNotValidModel(CartItemModel cartItemModel)
        {
            if (string.IsNullOrEmpty(cartItemModel.ProductId) || string.IsNullOrWhiteSpace(cartItemModel.ProductId))
                throw new ApplicationException("ProductId must not be empty");

            if (cartItemModel.Quantity <= 0)
                throw new ApplicationException("Quantity must be greater then 0");

            if (string.IsNullOrEmpty(cartItemModel.UserId) || string.IsNullOrWhiteSpace(cartItemModel.UserId))
                throw new ApplicationException("User must be authorized.");

            if (cartItemModel.Status != Models.Enums.CartStatus.New)
                throw new ApplicationException("Status must be new");
        }
    }
}
