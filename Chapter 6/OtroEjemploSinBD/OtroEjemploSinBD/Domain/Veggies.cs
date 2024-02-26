using OtroEjemploSinBD.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtroEjemploSinBD.Domain
{
    public class Veggies
    {
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

        public Veggies(List<Veggies> list)
        {
            vm = new VeggiesManage();
            vm.listVeggies = list;
        }

        /// <summary>
        /// JAJAJAJAJAJAJAJAJA
        /// </summary>
        /// <returns></returns>
        public List<Veggies> getL()
        {
            vm.readList();
            return vm.listVeggies;
        }

        /// <summary>
        /// JOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJO
        /// </summary>
        /// <returns></returns>
        public DataTable getD()
        {
            DataTable dt = vm.getData();
            return dt;
        }
    }
}
