using CicekSepetiCart.Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CicekSepetiCart.Test.TestData
{
    public class AddCartItem_ValidCartItem_ReturnTrue : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=1,
                Status = Application.Models.Enums.CartStatus.New,
                UserId = Guid.NewGuid().ToString()
                }
            };
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=3,
                Status = Application.Models.Enums.CartStatus.New,
                UserId = Guid.NewGuid().ToString()
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class AddCartItem_ValidCartItem_ReturnFalse : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CartItemModel()
                {
                Quantity=1,
                Status = Application.Models.Enums.CartStatus.New,
                UserId = Guid.NewGuid().ToString()
                }
            };
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=-1,
                Status = Application.Models.Enums.CartStatus.New,
                UserId = Guid.NewGuid().ToString()
                }
            };
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=3,
                Status = Application.Models.Enums.CartStatus.Completed,
                UserId = Guid.NewGuid().ToString()
                }
            };
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=3,
                Status = Application.Models.Enums.CartStatus.New
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class AddCartItem_InvalidBasketItemException : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CartItemModel()
                {
                Quantity=1,
                Status = Application.Models.Enums.CartStatus.New,
                UserId = Guid.NewGuid().ToString()
                }
            };
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=-1,
                Status = Application.Models.Enums.CartStatus.New,
                UserId = Guid.NewGuid().ToString()
                }
            };
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=3,
                Status = Application.Models.Enums.CartStatus.Completed,
                UserId = Guid.NewGuid().ToString()
                }
            };
            yield return new object[] { new CartItemModel()
                {
                ProductId = Guid.NewGuid().ToString(),
                Quantity=3,
                Status = Application.Models.Enums.CartStatus.New
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
