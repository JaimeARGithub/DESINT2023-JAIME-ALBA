using MiniHito2.Persistence.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito2.Domain
{
    class Party
    {
        public string acronym {  get; set; }
        public string name { get; set; }
        public string president { get; set; }

        public PartyManager pm { get; set; }


        public Party()
        {
            pm = new PartyManager();
        }

        public Party(string acronym, string name, string president)
        {
            this.acronym = acronym;
            this.name = name;
            this.president = president;
            pm = new PartyManager();
        }

        public void readP()
        {
            pm.readParties();
        }

        public List<Party> getListParties()
        {
            return pm.listParties;
        }
    }
}
