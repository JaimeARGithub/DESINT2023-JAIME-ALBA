using EjemploBD.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBD.Domain
{
    public class Lesbians
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bodycount { get; set; }
        private LesbiansManage lm { get; set; }


        public Lesbians()
        {
            lm = new LesbiansManage();
        }


        public Lesbians(int id)
        {
            this.Id = id;
            lm = new LesbiansManage();
        }


        public Lesbians(string name, int bodycount)
        {
            this.Name = name;
            this.Bodycount = bodycount;
            lm = new LesbiansManage();
        }



        public List<Lesbians> getBolleras()
        {
            lm.getAllLesbians();
            return this.lm.listLesbians;
        }

        public void insertL()
        {
            lm.insertLesbian(this);
        }

        public void updateL()
        {
            lm.updateLesbian(this);
        }

        public void lastID()
        {
            lm.lastId(this);
        }

        public void deleteL()
        {
            lm.deleteLesbian(this);
        }

        public DataTable getD()

        {
            return lm.getData();
        }
    }
}
