using System;

namespace CicekSepetiCart.API.ViewModels
{
    public class BaseModel
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
