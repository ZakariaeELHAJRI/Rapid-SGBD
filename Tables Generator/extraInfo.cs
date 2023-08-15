using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables_Generator
{
   public class extraInfo
    {

        public int floatNumber { get; set; }

        public int charMode { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public string CompareColumn { get; set; }
        public string CompareOperator { get; set; }
        public List<string> ChoixCategorie { get; set; }
        public extraInfo(int floaat, int charMode, DateTime dateDebut, DateTime dateFin)
        {

            floatNumber = floaat;

            this.charMode = charMode;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
        }
        public extraInfo(int floaat, int charMode, DateTime dateDebut, DateTime dateFin,List<string> ChoixCategorie,string cc,string co)
        {

            floatNumber = floaat;
            this.ChoixCategorie = ChoixCategorie;
            this.charMode = charMode;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            CompareColumn = cc;
            CompareOperator = co;
        }

        public extraInfo()
        {
        }
    }
}
