using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniHito2.Domain;

namespace MiniHito2.Persistence.Managers
{
    class PartyManager
    {
        public List<Party> listParties {  get; set; }


        public PartyManager()
        {
            listParties = new List<Party>();
        }


        public void readParties()
        {
            listParties.Add(new Party("P.1.", "Party1", "Liam Johnson"));
            listParties.Add(new Party("P.2.", "Party2", "James Williams"));
            listParties.Add(new Party("P.3.", "Party3", "Anne Smith"));
            listParties.Add(new Party("P.4.", "Party4", "Federica Federíquez"));
            listParties.Add(new Party("P.5.", "Party5", "Elpe Rosanxe"));
            listParties.Add(new Party("P.6.", "Party6", "Rocío Salgado"));
            listParties.Add(new Party("P.7.", "Party7", "Elongated Muskrat"));
            listParties.Add(new Party("P.8.", "Party8", "Déborah Martínez"));
            listParties.Add(new Party("P.9.", "Party9", "Me he quedado sin ideas :("));
        }
    }
}
