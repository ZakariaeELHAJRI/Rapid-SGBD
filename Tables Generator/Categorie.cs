using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tables_Generator
{
    [Serializable]
    public class Categorie 
    {
        public string Name { get; set; }
        public Bitmap Picture { get; set; }
        public List<string> Data { get; set; }
        public Categorie(string name) 
        {
            Name = name;
            Picture = new Bitmap(Tables_Generator.Properties.Resources.Unavailable);
            Data = new List<string>();
        }

        public Categorie(string name, Bitmap picture)
        {
            Name = name;
            if (picture == null)
            {
                Picture = new Bitmap(Tables_Generator.Properties.Resources.Unavailable);
            }
            else Picture = picture;
            Data = new List<string>();
        }
    }
}
