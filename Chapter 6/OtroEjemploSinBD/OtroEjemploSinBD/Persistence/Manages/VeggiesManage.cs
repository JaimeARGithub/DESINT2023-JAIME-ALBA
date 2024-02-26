using OtroEjemploSinBD.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtroEjemploSinBD.Persistence.Manages
{
    public class VeggiesManage
    {
        public List<Veggies> listVeggies {  get; set; }


        public VeggiesManage()
        {
            listVeggies = new List<Veggies>();
        }

        public void readList()
        {
            listVeggies.Add(new Veggies("Potato", "Brown", 5));
            listVeggies.Add(new Veggies("Broccoli", "Green", 1));
            listVeggies.Add(new Veggies("Carrot", "Orange", 13));
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("Name");
            DataColumn c2 = new DataColumn("Color");
            DataColumn c3 = new DataColumn("Weight");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            DataRow row = null;
            foreach (Veggies v in listVeggies)
            {
                row = dt.NewRow();

                row[0] = v.Name;
                row[1] = v.Color;
                row[2] = v.Weight;

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
