using Ejemplo.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo.Domain
{

    public class Players
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Position {  get; set; }
        public int Age { get; set; }

        public PlayersManage pm { get; set; }

        
        public Players()
        {
            pm = new PlayersManage();
        }

        public Players(List<Players> listPlayers)
        {
            pm = new PlayersManage(listPlayers);
        }


        public Players(string dni, string name, string surnames, string position, int age)
        {
            this.DNI = dni;
            this.Name = name;
            this.Surnames = surnames;
            this.Position = position;
            this.Age = age;

            pm = new PlayersManage();
        }

        public List<Players> readP()
        {
            return pm.readPlayers();
        }

        public DataTable getD()
        {
            return pm.getData();
        }

        public void getWBT()
        {
            pm.getWhiteBoxTest();
        }
    }
}
