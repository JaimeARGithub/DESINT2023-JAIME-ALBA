using EjemploExamen.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EjemploExamen.Persistence.Manage
{
    class ProductManage
    {
        public List<Product> productList { get; set; }

        public ProductManage()
        {
            this.productList = new List<Product>();
        }

        public void readProductos()
        {
            Product p = null;
            List<Object> lproduct;
            lproduct = DBBroker.obtenerAgente().leer("select * from Products order by idProduct");

            foreach (List<Object> aux in lproduct) {
                p = new Product(Int32.Parse(aux[0].ToString()));

                p.amount = Int32.Parse(aux[1].ToString());
                p.product_name = aux[2].ToString();
                p.price = Math.Round(Double.Parse(aux[3].ToString()), 2, MidpointRounding.AwayFromZero);

                this.productList.Add(p);
            }
        }

        public void insertProduct(Product p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("insert into Products(Amount, Name, Price) values(" + p.amount + ", '" + p.product_name + "', " + p.price.ToString(CultureInfo.InvariantCulture) + ")");
            dBBroker.modificar("insert into Products(Amount, Name, Price) values(" + p.amount + ", '" + p.product_name + "', " + p.price.ToString(CultureInfo.InvariantCulture) + ")");
        }

        public void lastId(Product p)
        {
            List<Object> lproduct;
            lproduct = DBBroker.obtenerAgente().leer("select MAX(idProduct) from Products");
            foreach (List<Object> aux in lproduct)
            {
                p.Id = Convert.ToInt32(aux[0]);
            }
        }

        public void deleteProduct(Product p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("delete from Products where idProduct="+p.Id);
            dBBroker.modificar("delete from Products where idProduct=" + p.Id);
        }

        public void updateProduct(Product p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("update Products set Amount="+p.amount+", Name='"+p.product_name+"', Price="+p.price.ToString(CultureInfo.InvariantCulture) + " where idProduct="+p.Id);
            dBBroker.modificar("update Products set Amount=" + p.amount + ", Name='" + p.product_name + "', Price=" + p.price.ToString(CultureInfo.InvariantCulture) + " where idProduct=" + p.Id);
        }
    }
}
