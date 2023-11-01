using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tables_Generator
{
   public class Column
    {
        public Column()
        {
        }
        public Column(string nom, string type, bool unique, bool primarykey, bool @null, bool @default, bool identity, bool check, string defaultValue, int identitySeed, int identityIncrement, string checkOperator, string[] checkValue1, string checkValue2, string fKtable, string fKcolumn, bool fk)
        {
            Nom = nom;
            Type = type;
           
            Primarykey = primarykey;
           
            Null = @null;
           
            Unique = unique;
         
            Identity = identity;
            Default = @default;
            Check = check;
            DefaultValue = defaultValue;
            CheckOperator = checkOperator;
            CheckValue1 = checkValue1;
            CheckValue2 = checkValue2;
            IdentitySeed = identitySeed;
            IdentityStep = identityIncrement;
            FKtable = fKtable;
            FKcolumn = fKcolumn;
            Fk = fk;
        }

        public string Nom { get; set; }
        public string Type { get; set; }
        public bool Primarykey { get; set; }
        public bool Null { get; set; }
        public bool Unique { get; set; }
        public bool Identity { get; set; }
        public bool Default { get; set; }
        public bool Check { get; set; }
        public bool Fk { get; set; }
        public string DefaultValue { get; set; }
        public string CheckOperator { get; set; }
        public string[] CheckValue1 { get; set; }
        public string CheckValue2 { get; set; }
        public int IdentitySeed { get; set; }
        public int IdentityStep { get; set; }
        public string FKtable { get; set; }
        public string FKcolumn { get; set; }

    }
}
