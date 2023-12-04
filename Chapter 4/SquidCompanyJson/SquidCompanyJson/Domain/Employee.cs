using Newtonsoft.Json;
using SquidCompanyJson.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquidCompanyJson.Domain
{
    internal class Employee
    {
        public int Id { get; set; }
        public string nif { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }

        [JsonIgnore]
        public EmployeeManage em { get; set; }


        public Employee()
        {
            em = new EmployeeManage();
        }

        public Employee(int id)
        {
            this.Id = id;
            em = new EmployeeManage();
        }

        public Employee(string nif, string name, string surname, int age)
        {
            this.nif = nif;
            this.name = name;
            this.surname = surname;
            this.age = age;
            em = new EmployeeManage();
        }

        public void readE()
        {
            em.readEmployee();
        }

        public List<Employee> getList()
        {
            return em.listEmployee;
        }


        public void insert()
        {
            em.insertEmployee(this);
        }

        public void last()
        {
            em.lastId(this);
        }

        public void delete()
        {
            em.deleteEmployee(this);
        }

        public void update()
        {
            em.updateEmployee(this);
        }
    }
}
