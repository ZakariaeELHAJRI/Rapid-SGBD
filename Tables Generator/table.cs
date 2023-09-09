using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tables_Generator
{
   public class table
    {
        public table(string tableName, List<Column> columns, List<extraInfo> extra)
        {
            this.tableName = tableName;
            this.columns = columns;
            this.extra = extra;
            insert = new List<string>();
        }
        public table()
        {

        }
        public string tableName { get; set; }
        public List<Column> columns { get; set; }
        public List<extraInfo> extra { get; set; }
        public List<string> insert { get; set; }
        public bool isValid()
        {
            if (columns.Count == 0) return false;
            foreach (var item in columns)
            {
                if (item.Nom == string.Empty || item.Type == string.Empty) return false;
            }
            return true;
        }
        public List<string> getPKNames() // get primary key columns
        {
            var x = new List<string>();
            foreach (var item in columns)
            {
                if (item.Primarykey)
                    x.Add(item.Nom);
            }
            return x;
        }

        public List<string> getStColumns(int ColumnIndex) //get Same type columns
        {
            var x = new List<string>();
            for (int i = 0; i < columns.Count; i++)
            {
                if (i == ColumnIndex) continue;
                if (columns[i].Type==columns[ColumnIndex].Type)
                    x.Add(columns[i].Nom);
            }
            return x;
        }
       
    }
}
