using ProjectMicroservices.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectMicroservices.Order.Domain.OrderAggregate
{
    public class OrderItem:Entity
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public decimal Price { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(string productId, string name, string pictureURL, decimal price)
        {
            ProductId = productId;
            Name = name;
            PictureURL = pictureURL;
            Price = price;
        }

        public void UpdateOrderItem(string name, string pictureURL, decimal price)
        {
           
            Name = name;
            PictureURL = pictureURL;
            Price = price;
        }
    }
}
