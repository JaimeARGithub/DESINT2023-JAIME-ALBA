using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleMVCNoDatabase.Persistence.Manages;

namespace ExampleMVCNoDatabase.Domain
{
    public class People
    {
        private String name;
        private int age;
        private PeopleManage pm;

        public People(String nameIntr, int ageIntr)
        {
            this.Name = nameIntr;
            this.Age = ageIntr;
            Pm = new PeopleManage();
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public PeopleManage Pm { get => pm; set => pm = value; }
    }
}
