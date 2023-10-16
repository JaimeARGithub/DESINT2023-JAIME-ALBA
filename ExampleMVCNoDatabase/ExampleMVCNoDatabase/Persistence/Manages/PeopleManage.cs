using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleMVCNoDatabase.Domain;

namespace ExampleMVCNoDatabase.Persistence.Manages
{
    public class PeopleManage
    {
        private DataTable table;
        private List<People> listPeople;

        public PeopleManage()
        {
            this.table = new DataTable();
            ListPeople = new List<People>();
        }

        public DataTable Table { get => table; set => table = value; }
        public List<People> ListPeople { get => listPeople; set => listPeople = value; }

        // To insert customers
        public void readPeople()
        {
            ListPeople.Add(new People("Neil", 42));
            ListPeople.Add(new People("Jimi", 20));
            ListPeople.Add(new People("Yara", 19));
        }
    }
}
