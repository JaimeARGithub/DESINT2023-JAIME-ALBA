using MiniHito3Json.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito3Json.Persistence.Manages
{
    class PartyManage
    {
        public List<Party> listParties { get; set; }
        private string contenidoJSon;
        private string ruta;


        public PartyManage()
        {
            listParties = new List<Party>();
            ruta = "sample_party.json";
        }


        public void readParties()
        {
            string contenidoJSon = File.ReadAllText(ruta);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJSon);
            listParties = rootObject.party;
        }


        public void insertParty(Party p)
        {
            p.last();
            listParties.Add(p);

            RootObject rootObject = new RootObject();
            rootObject.party = listParties;
            string contenidoJSon = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(ruta, contenidoJSon);
        }


        public void lastId(Party p)
        {
            p.Id = MaxId() + 1;
        }


        private int MaxId()
        {
            int max = 0;
            foreach (Party p in listParties)
            {
                if (p.Id > max)
                {
                    max = p.Id;
                }
            }

            return max;
        }


        class RootObject
        {
            [JsonProperty("party")]
            public List<Party> party { get; set; }
        }
    }
}
