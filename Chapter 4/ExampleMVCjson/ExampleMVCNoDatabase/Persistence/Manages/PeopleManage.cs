using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using ExampleMVCnoDatabase.Domain;
using ExampleMVCnoDatabase.Persistence;
using System.IO;

namespace ExampleMVCnoDatabase.Persistence.Manages
{
    internal class PeopleManage
    {
        public List<People> listPeople { get; set; }
        private string contenidoJSon;
        private string ruta;

        public PeopleManage()
        {
            listPeople = new List<People>();
            ruta = "sample4.json"; // Ruta relativa
        }

        public void readPeople()
        {
            string contenidoJson = File.ReadAllText(ruta);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);
            listPeople = rootObject.people;
        }

        public void insertPeople(People p)
        {
            p.last();
            listPeople.Add(p);

            RootObject rootObject = new RootObject();
            rootObject.people = listPeople;
            string contenidoJSon = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(ruta, contenidoJSon);
        }

        public void lastId(People p)
        {
            p.Id = MaxId() + 1;
        }

        private int MaxId()
        {
            int max = 0;
            foreach (People people in listPeople)
            {
                if (people.Id > max)
                {
                    max = people.Id;
                }
            }

            return max;
        }

        public void deletePeople(People p)
        {
            RemoveById(p);

            RootObject rootObject = new RootObject();
            rootObject.people = listPeople;
            string contenidoJSon = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(ruta, contenidoJSon);
        }

        private bool RemoveById(People p)
        {
            foreach (People people in listPeople)
            {
                if (people.Id == p.Id)
                {
                    listPeople.Remove(people);
                    return true;
                }
            }

            return false;
        }

        public bool updatePeople(People p)
        {
            if (RemoveById(p))
            {
                insertPeople(p);
                return true;
            } 
            else
            {
                return false;
            }
        }

        class RootObject
        {
            [JsonProperty("people")]
            public List<People> people { get; set; }
        }
    }
}
