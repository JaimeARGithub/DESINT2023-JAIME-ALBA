using Ejemplo.Domain;
using Ejemplo.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo.Persistence.Manages
{
    public class PlayersManage
    {
        public List<Players> listPlayers;

        public PlayersManage()
        {
            listPlayers = new List<Players>();
        }

        public List<Players> readPlayers()
        {
            listPlayers.Add(new Players("11111111A", "Perico", "Palotes", "Front", 24));
            listPlayers.Add(new Players("22222222B", "Pablo", "Motos", "Back", 32));
            listPlayers.Add(new Players("33333333C", "Edu", "Pelotas", "Porterillo", 44));

            return listPlayers;
        }
    }
}
