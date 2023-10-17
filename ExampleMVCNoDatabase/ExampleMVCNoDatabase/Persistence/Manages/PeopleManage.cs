using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using ExampleMVCnoDatabase.Domain;

namespace ExampleMVCnoDatabase.Persistence.Manages
{
    internal class PeopleManage
    {
        private DataTable table;
        private List<People> listPeople;

        public DataTable Table { get => table; set => table = value; }
        internal List<People> ListPeople { get => listPeople; set => listPeople = value; }

        public PeopleManage()
        {
            table=new DataTable();
            ListPeople=new List<People>();
        }

        public void readPeople()
        {
            ListPeople.Add(new People("Neil",42));
            ListPeople.Add(new People("Jimi", 20));
            ListPeople.Add(new People("Valverde", 19));
        }

    }
}
