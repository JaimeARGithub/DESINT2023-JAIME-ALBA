using Personas.persistence;
using ShoppingList.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoppingList.Persistence.Manage
{
    class CompraManage
    {
        public List<Compra> listCompra { get; set; }

        public CompraManage()
        {
            this.listCompra = new List<Compra>();
        }

        public void readCompra()
        {
            Compra compra=null;
            List<Object> aux = DBBroker.obtenerAgente().leer("Select * from shoppinglist.compras;");
            foreach (List<Object> c in aux)
            {
                compra = new Compra(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), c[2].ToString(), Convert.ToDouble(c[3]));
                this.listCompra.Add(compra);
            }
        }

        public void lastId(Compra c)
        {
            List<Object> lcompra;
            lcompra = DBBroker.obtenerAgente().leer("select MAX(idCompra) from compras");
            foreach (List<Object> aux in lcompra)
            {
                c.Id = Convert.ToInt32(aux[0]);
            }
        }

        public void insert(Compra c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("insert into compras(amount, product, price) values(" + c.Amount+ ",'" + c.Product + "'," + c.Price.ToString(CultureInfo.InvariantCulture) + ")");
        }

        public void delete(Compra c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("delete from compras where idCompra=" + c.Id);
        }

        public void update(Compra c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("update compras set amount=" + c.Amount + ", product='" + c.Product + "', price=" + c.Price.ToString(CultureInfo.InvariantCulture) + " where idCompra=" + c.Id);
        }
    }
}
