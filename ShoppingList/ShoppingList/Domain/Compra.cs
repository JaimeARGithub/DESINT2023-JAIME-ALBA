using ShoppingList.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain
{
    class Compra
    {
        private int id;
        private int amount;
        private string product;
        private double price;
        private CompraManage cm;

        public Compra()
        {
            cm = new CompraManage();
        }

        public Compra(int amount, string product, double price) 
            : this(-1, amount, product, price)
        {
            //nada
        }

        public Compra(int id, int amount, string product, double price)
        {
            this.id = id;
            this.amount = amount;
            this.product = product;
            this.price = price;

            this.cm = new CompraManage();
        }

        public void last()
        {
            cm.lastId(this);
        }

        public void readC()
        {
            cm.readCompra();
        }

        public List<Compra> getListCompra()
        {
            return cm.listCompra;
        }

        public void insert()
        {
            cm.insert(this);
        }

        public void delete()
        {
            cm.delete(this);
        }

        public void update()
        {
            cm.update(this);
        }

        //---

        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount= value; }
        public string Product { get => product; set => product = value; }
        public double Price { get => price; set => price = value; }
    }
}
