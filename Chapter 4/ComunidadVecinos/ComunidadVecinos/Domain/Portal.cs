using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComunidadVecinos.Domain
{
    public class Portal
    {
        public static int autoID = 0;
        public int Idportal { get; set; }
        public int idComunidad {  get; set; }
        public int numEscaleras { get; set; }
        public int numPlantas { get; set; }
        public int numPuertas { get; set; }
        public List<Piso> listaPisos { get; set; }


        public Portal(int idCom, int numEscaleras, int numPlantas, int numPuertas)
        {
            this.Idportal = autoID++;
            this.idComunidad = idCom;
            this.numEscaleras = numEscaleras;
            this.numPlantas = numPlantas;
            this.numPuertas = numPuertas;
            listaPisos = new List<Piso>();
        }

        public void generarPisos()
        {
            for (int esc=0; esc<=numEscaleras; esc++)
            {
                for (int pla=0; pla<=numPlantas; pla++)
                {
                    for (int let=1; let<=numPuertas; let++)
                    {
                        listaPisos.Add(new Piso(idComunidad, Idportal, esc, pla, Convert.ToChar('A' + let - 1).ToString()));
                    }
                }
            }
        }

        public void toString()
        {
            MessageBox.Show($"Number of stairs: {numEscaleras}. Number of floors: {numPlantas}. Number of doors: {numPuertas}");
        }
    }
}
