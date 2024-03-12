using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SQLBEBEBEEBE.Model;

namespace SQLBEBEBEEBE.ViewModel
{
    internal class MainViewModel
    {
        public int article;
        public string name;
        public string description;
        public string category;
        public string photo;
        public string manufacturer;
        public int cost;
        public int discountAmount;
        public int quantity;

        private RelayCommand addProductCommand;
        private RelayCommand updateProductCommand;
        private RelayCommand deleteProductCommand;

        public RelayCommand AddProductCommand
        {
            get
            {
                return addProductCommand ??
                  (addProductCommand = new RelayCommand(obj =>
                  {
                      Product NewProduct = new Product(article, name, description, category, photo, manufacturer, cost, discountAmount, quantity);

                      AddProduct(NewProduct);

                  }));
            }
        }
        public string AddProduct(Product NewProduct)
        {
            string Add;
            Add = $"INSERT INTO Product VALUES({NewProduct.Article},'{NewProduct.Name}','{NewProduct.Description}','{NewProduct.Category}','{NewProduct.Photo}','{NewProduct.Manufacturer}',{NewProduct.Cost},{NewProduct.DiscountAmount},{NewProduct.Quantity})";
            return Add ;
        }

        public RelayCommand UpdateProductCommand
        {
            get
            {
                return updateProductCommand ??
                  (updateProductCommand = new RelayCommand(obj =>
                  {
                      //SelectedArticle = selectedArticle;
                      //SelectedItem = selectedItem;

                      UpdateProduct();

                  }));
            }
        }
        public string UpdateProduct()
        {
            string Add;
            Add = $"UPDATE Product SET )";
            return Add;
        }

        public RelayCommand DeleteProductCommand
        {
            get
            {
                return deleteProductCommand ??
                  (deleteProductCommand = new RelayCommand(obj =>
                  {
                      //SelectedArticle = selectedArticle;

                      DeleteProduct();

                  }));
            }
        }
        public string DeleteProduct()
        {
            string Add;
            Add = $"DELETE FROM Product WHERE Article = SelectedArticle)";
            return Add;
        }
    }

}

