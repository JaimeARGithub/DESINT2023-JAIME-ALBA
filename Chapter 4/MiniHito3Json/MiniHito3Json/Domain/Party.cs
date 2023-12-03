using MiniHito3Json.Persistence.Manages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito3Json.Domain
{
    class Party
    {
        public int Id { get; set; }
        public string party { get; set; }
        public int votes { get; set; }
        public int seats { get; set; }

        [JsonIgnore]
        public PartyManage pm { get; set; }



        public Party()
        {
            pm = new PartyManage();
        }

        public Party(int id)
        {
            pm = new PartyManage();
            this.Id = id;
        }

        public Party(string party, int votes, int seats)
        {
            this.party = party;
            this.votes = votes;
            this.seats = seats;

            pm = new PartyManage();
        }

        public void readP()
        {
            pm.readParties();
        }

        public List<Party> getListPeople()
        {
            return pm.listParties;
        }

        public void insert()
        {
            pm.insertParty(this);
        }

        public void last()
        {
            pm.lastId(this);
        }
    }
}





