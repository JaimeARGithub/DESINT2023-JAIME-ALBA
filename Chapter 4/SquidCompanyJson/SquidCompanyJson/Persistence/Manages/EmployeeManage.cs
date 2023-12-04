using Newtonsoft.Json;
using SquidCompanyJson.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquidCompanyJson.Persistence.Manages
{
    internal class EmployeeManage
    {
        public List<Employee> listEmployee { get; set; }
        private string contenidoJSon;
        private string ruta;


        public EmployeeManage()
        {
            listEmployee = new List<Employee>();
            ruta = "sample_employee.json";
        }

        public void readEmployee()
        {
            string contenidoJson = File.ReadAllText(ruta);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);
            listEmployee = rootObject.employee;
        }

        public void insertEmployee(Employee e)
        {
            e.last();
            listEmployee.Add(e);

            RootObject rootObject = new RootObject();
            rootObject.employee = listEmployee;
            string contenidoJSon = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(ruta, contenidoJSon);
        }

        public void lastId(Employee e)
        {
            e.Id = MaxId() + 1;
        }

        private int MaxId()
        {
            int max = 0;
            foreach (Employee employee in listEmployee)
            {
                if (employee.Id > max)
                {
                    max = employee.Id;
                }
            }

            return max;
        }

        public void deleteEmployee(Employee e)
        {
            RemoveById(e);

            RootObject rootObject = new RootObject();
            rootObject.employee = listEmployee;
            string contenidoJSon = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(ruta, contenidoJSon);
        }

        private bool RemoveById(Employee e)
        {
            foreach (Employee employee in listEmployee)
            {
                if (employee.Id == e.Id)
                {
                    listEmployee.Remove(employee);
                    return true;
                }
            }

            return false;
        }

        public bool updateEmployee(Employee e)
        {
            if (RemoveById(e))
            {
                insertEmployee(e);
                return true;
            }
            else
            {
                return false;
            }
        }

        class RootObject
        {
            [JsonProperty("employee")]
            public List<Employee> employee { get; set; }
        }
    }
}
