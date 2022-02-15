using System;

namespace CicekSepetiCart.Application.Models
{
    public class BaseModel
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
