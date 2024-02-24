using Ejemplo.Domain;
using Ejemplo.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ejemplo.Persistence.Manages
{
    public class PlayersManage
    {
        public List<Players> listPlayers;

        public PlayersManage()
        {
            listPlayers = new List<Players>();
        }

        public PlayersManage(List<Players> listPlayers)
        {
            this.listPlayers = listPlayers;
        }

        public List<Players> readPlayers()
        {
            listPlayers.Add(new Players("11111111A", "Perico", "Palotes", "Front", 24));
            listPlayers.Add(new Players("22222222B", "Pablo", "Motos", "Back", 32));
            listPlayers.Add(new Players("33333333C", "Edu", "Pelotas", "Porterillo", 44));

            return listPlayers;
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();

            DataColumn c1 = new DataColumn("DNI");
            DataColumn c2 = new DataColumn("Name");
            DataColumn c3 = new DataColumn("Surnames");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            DataRow row = null;
            foreach(Players p in listPlayers)
            {
                row = dt.NewRow();
                row[0] = p.DNI;
                row[1] = p.Name;
                row[2] = p.Surnames;

                dt.Rows.Add(row);
            }

            return dt;
        }

        public void getWhiteBoxTest2()
        {
            double avgAge = 0;
            double totalCounted = 0;

            foreach(Players p in listPlayers)
            {
                totalCounted++;
                avgAge += p.Age;
            }

            avgAge = avgAge / totalCounted;

            String data = "The average age in the playerbase is " + avgAge.ToString("F2") + " years old.";
            MessageBox.Show(data);
        }

        public void getWhiteBoxTest()
        {
            string data = "";
            int counter = 0;

            foreach (Players p in listPlayers)
            {
                if (p.Age < 10)
                {
                    data = data + "The player " + p.Name + " is " + p.Age.ToString() + " years old.\n";
                    counter++;
                }
            }
            data = data + "\nThere are " + counter + " players younger than 10 years old.";


            if (counter>0)
            {
                MessageBox.Show(data);
            } else
            {
                MessageBox.Show("There are no players younger than 10 years old.");
            }
        }
    }
}
