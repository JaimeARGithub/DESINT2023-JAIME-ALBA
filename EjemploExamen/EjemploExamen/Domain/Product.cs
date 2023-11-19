using EjemploExamen.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploExamen.Domain
{
    class Product
    {
        public int Id { get; set; }
        
        public int amount {  get; set; }
        public string product_name { get; set; }
        public double price { get; set; }

        public ProductManage pm { get; set; }


        public Product()
        {
            this.pm = new ProductManage();
        }

        public Product(int id)
        {
            this.Id = id;
            this.pm = new ProductManage();
        }

        public Product (int am, string nom, double pri)
        {
            this.amount = am;
            this.product_name = nom;
            this.price = pri;
            this.pm = new ProductManage();
        }

        public void readP()
        {
            pm.readProductos();
        }

        public List<Product> getLista()
        {
            return pm.productList;
        }

        public void insert()
        {
            pm.insertProduct(this);
        }

        public void last()
        {
            pm.lastId(this);
        }

        public void delete()
        {
            pm.deleteProduct(this);
        }

        public void update()
        {
            pm.updateProduct(this);
        }
    }
}
