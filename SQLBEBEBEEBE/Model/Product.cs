using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBEBEBEEBE.Model
{
    internal class Product
    {
        public int Article;
        public string Name;
        public string Description;
        public string Category;
        public string Photo;
        public string Manufacturer;
        public int Cost;
        public int DiscountAmount;
        public int Quantity;

        public Product(int article, string name, string description, string category, string photo, string manufacturer, int cost, int discountAmount, int quantity)
        {
            Article = article;
            Name = name;
            Description = description;
            Category = category;
            Photo = photo;
            Manufacturer = manufacturer;
            Cost = cost;
            DiscountAmount = discountAmount;
            Quantity = quantity;
        }
    }
}
