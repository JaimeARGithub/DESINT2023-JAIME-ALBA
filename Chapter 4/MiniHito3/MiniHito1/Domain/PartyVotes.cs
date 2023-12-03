using MiniHito2.Persistence.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito2.Domain
{
    internal class PartyVotes
    {
        public string party { get; set; }
        public int votes { get; set; }
        public int seats { get; set; }


        public PartyVotes(string party, int votes, int seats)
        {
            this.party = party;
            this.votes = votes; ;
            this.seats = seats;
        }
    }
}
