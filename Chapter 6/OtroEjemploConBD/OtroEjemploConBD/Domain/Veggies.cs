using OtroEjemploConBD.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtroEjemploConBD.Domain
{
    public class Veggies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public VeggiesManage vm { get; set; }


        public Veggies()
        {
            vm = new VeggiesManage();
        }


        public Veggies(string name, string color, int weight)
        {
            this.Name = name;
            this.Color = color;
            this.Weight = weight;
            vm = new VeggiesManage();
        }


        public void readV()
        {
            vm.readAllVeggies();
        }

        public List<Veggies> getV()
        {
            return vm.listVeggies;
        }

        public void deleteV()
        {
            vm.deleteVeggie(this);
        }

        public void insertV()
        {
            vm.insertVeggie(this);
        }

        public void lastId()
        {
            vm.selectMaxID(this);
        }

        public void updateV()
        {
            vm.updateVeggie(this);
        }

        public DataTable getD()
        {
            return vm.getData();
        }
    }
}
