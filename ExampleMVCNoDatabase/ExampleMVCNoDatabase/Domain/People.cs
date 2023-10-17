using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleMVCnoDatabase.Persistence.Manages;

namespace ExampleMVCnoDatabase.Domain
{
    internal class People
    {
        private String name;
        private int age;
        private PeopleManage pm;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        internal PeopleManage Pm { get => pm; set => pm = value; }

        public People(string name, int age)
        {
            this.name = name;
            this.age = age;
            pm = new PeopleManage();
        }

       
    }
}
