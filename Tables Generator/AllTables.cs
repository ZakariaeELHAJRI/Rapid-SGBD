using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tables_Generator
{
    public static class AllTables
    {
        public static string dbname;
        public static List<table> Tables;
        public static DataSet TablesDs;
        
        public static bool dbFull
        {
            get
            {
                foreach (DataTable item in TablesDs.Tables)
                {
                    if (item.Rows.Count == 0) return false;
                }
                return true;
            }
        }

        #region tablesMethodes
        public static void reset()
        {
            Tables = new List<table>();
            TablesDs = new DataSet();
            dbname = "";

        }
        public static List<string> getTablesNames(int except)
        {

            var x = new List<string>();
            var not = new List<table>() { Tables[except] };
            foreach (var item in Tables.Except(not))
            {
                foreach (var col in item.columns)
                {
                    if (col.Primarykey)
                    {

                        x.Add(item.tableName);
                        break;
                    }
                }
            }
            return x;
        }
        public static string getColumnType(string TableIndex, string ColumnIndex)
        {
            int tIndex = Tables.FindIndex(t => t.tableName == TableIndex);
            int cindex = Tables[tIndex].columns.FindIndex(w => w.Nom == ColumnIndex);

            return Tables[tIndex].columns[cindex].Type;

        }

        private static Type jibtype(string type)
        {

            if (type == "Int") return typeof(int);
            if (type == "String") return typeof(string);
            if (type == "Bool") return typeof(bool);
            if (type == "Double") return typeof(double);
            if (type == "Char") return typeof(char);
            if (type == "Time") return typeof(string);

            else return typeof(DateTime);

        }
        private static string revertType(string type)
        {

            string result;
            switch (type.ToLower())
            {
                case "int": result = "int"; break;
                case "string": result = "varchar(900)"; break;
                case "bool": result = "bit"; break;
                case "double": result = "float"; break;
                case "date": result = "date"; break;
                case "time": result = "time(0)"; break;
                case "char": result = "varchar(2)"; break;
                default: result = string.Empty; break;
            }
            return result.ToUpper();
        }

        private static string getvalues(string[] values)
        {
            StringBuilder result = new StringBuilder("(");
            foreach (var item in values)
            {
                result.Append($"'{item}',");
            }
            result.Remove(result.Length - 1, 1);
            result.Append(")");
            return result.ToString();
        }
        private static List<dynamic> foreignkey(DataTable target, string columnindex, int nbrfoix)
        {
            var list = new List<dynamic>();
            Random rand = new Random();
            foreach (DataRow item in target.Rows)
            {
                if (list.Contains(item[columnindex])) continue;
                list.Add(item[columnindex]);
            }

            var shuffledList = new List<dynamic>();
            for (int i = 0; i < nbrfoix; i++)
            {
                shuffledList.Add(list[rand.Next(list.Count)]);
            }
            return shuffledList;
        }
        public static void cleanrows(int index)
        {
            TablesDs.Tables[index].Rows.Clear();
        }
        #endregion

        #region generateDbScripts
        public static string generateCreatedb()
        {

            StringBuilder create = new StringBuilder();
            create.AppendLine("USE master \n go");
            create.AppendLine($"DROP DATABASE IF EXISTS [{dbname}]");
            create.AppendLine($" CREATE DATABASE [{dbname}] \n go ");
            create.AppendLine($"Use [{dbname}] \n go ");



            foreach (var table in Tables)
            {
                create.AppendLine($"CREATE TABLE [{table.tableName}]  (");
                for (int i = 0; i < table.columns.Count; i++)
                {
                    string id = (table.columns[i].Identity) ? $"IDENTITY({table.columns[i].IdentitySeed},{table.columns[i].IdentityStep}) " : "";

                    if (revertType(table.columns[i].Type) != string.Empty)
                        create.AppendLine($"\t [{table.columns[i].Nom}] {revertType(table.columns[i].Type)}   {id}  ,");
                    else //fk
                        create.AppendLine($"\t [{table.columns[i].Nom}] {revertType(getColumnType(table.columns[i].FKtable, table.columns[i].FKcolumn))} ,");

                }

                create.Remove(create.Length - 1, 1);
                create.AppendLine(")");

            }
            return create.ToString();

        }
        public static string generateconstraint()
        {

            StringBuilder sb = new StringBuilder();
            foreach (var item in Tables)
            {
                if (NotNull(item) != "")
                    sb.AppendLine(NotNull(item));

            }
            foreach (var item in Tables)
            {
                if (primaryClustred(item) != "")
                    sb.AppendLine(primaryClustred(item));

            }
            foreach (var item in Tables)
            {
                if (Unique(item) != "")

                    sb.AppendLine(Unique(item));

            }
            foreach (var item in Tables)
            {
                if (foreignkey(item) != "")

                    sb.AppendLine(foreignkey(item));
            }
            foreach (var item in Tables)
            {
                if (check(item) != "")

                    sb.AppendLine(check(item));
            }
            foreach (var item in Tables)
            {
                if (defaultC(item) != "")
                    sb.AppendLine(defaultC(item));

            }
            return sb.ToString();

        }
        public static string generateCreateTable(int TableIndex)
        {
            StringBuilder create = new StringBuilder();

            create.AppendLine($"CREATE TABLE [{Tables[TableIndex].tableName}]  (");
            for (int i = 0; i < Tables[TableIndex].columns.Count; i++)
            {
                string id = Tables[TableIndex].columns[i].Identity ? $"IDENTITY({Tables[TableIndex].columns[i].IdentitySeed},{Tables[TableIndex].columns[i].IdentityStep}) " : "";

                if (revertType(Tables[TableIndex].columns[i].Type) != string.Empty)
                    create.AppendLine($"\t [{Tables[TableIndex].columns[i].Nom}] {revertType(Tables[TableIndex].columns[i].Type)}   {id}  , ");
                else
                    create.AppendLine($"\t [{Tables[TableIndex].columns[i].Nom}] {revertType(getColumnType(Tables[TableIndex].columns[i].FKtable, Tables[TableIndex].columns[i].FKcolumn))} ,");

            }

            create.Remove(create.Length - 1, 1);
            create.AppendLine(")");
            return create.ToString();
        }
        public static string generateconstraintTable(int TableIndex)
        {
            StringBuilder sb = new StringBuilder();

            if (NotNull(Tables[TableIndex]) != "")
                sb.AppendLine(NotNull(Tables[TableIndex]));
            if (primaryClustred(Tables[TableIndex]) != "")
                sb.AppendLine(primaryClustred(Tables[TableIndex]));
            if (Unique(Tables[TableIndex]) != "")

                sb.AppendLine(Unique(Tables[TableIndex]));
            if (foreignkey(Tables[TableIndex]) != "")

                sb.AppendLine(foreignkey(Tables[TableIndex]));
            if (check(Tables[TableIndex]) != "")

                sb.AppendLine(check(Tables[TableIndex]));
            if (defaultC(Tables[TableIndex]) != "")
                sb.AppendLine(defaultC(Tables[TableIndex]));
            return sb.ToString();

        }
        private static string primaryClustred(table t)
        {
            StringBuilder primaryKeySql = new StringBuilder($"ALTER TABLE [{ t.tableName }] ADD CONSTRAINT PK_{ t.tableName} PRIMARY KEY (");
            bool exist = false;
            for (int i = 0; i < t.columns.Count; i++)
            {
                if (t.columns[i].Primarykey)
                {
                    exist = true;
                    primaryKeySql.AppendFormat("{0},", t.columns[i].Nom);
                }

            }
            primaryKeySql.Remove(primaryKeySql.Length - 1, 1);
            primaryKeySql.Append(")");
            if (exist)
                return primaryKeySql.ToString();
            else
                return "";
        }
        private static string Unique(table t)
        {
            StringBuilder uniqueKeySql = new StringBuilder();
            bool exist = false;
            for (int i = 0; i < t.columns.Count; i++)
            {
                if (t.columns[i].Unique)
                {
                    exist = true;

                    uniqueKeySql.AppendLine($"ALTER TABLE [{ t.tableName }] ADD CONSTRAINT U_{t.tableName}{t.columns[i].Nom} UNIQUE({t.columns[i].Nom} )");
                }


            }
            if (exist)
                return uniqueKeySql.ToString();
            else
                return "";
        }
        private static string foreignkey(table t)
        {

            StringBuilder foreignKeySql = new StringBuilder();
            bool exist = false;
            for (int i = 0; i < t.columns.Count; i++)
            {
                if (t.columns[i].Fk)
                {
                    foreignKeySql.AppendLine($"ALTER TABLE [{ t.tableName }]  ADD CONSTRAINT FK_{t.tableName}{ t.columns[i].Nom} FOREIGN KEY({t.columns[i].Nom}) REFERENCES {TablesDs.Tables[t.columns[i].FKtable].TableName}({TablesDs.Tables[t.columns[i].FKtable].Columns[t.columns[i].FKcolumn].ColumnName})");

                    exist = true;
                }
            }
            if (exist)
                return foreignKeySql.ToString();
            else return "";

        }
        private static string NotNull(table t)
        {
            StringBuilder nullKeySql = new StringBuilder();
            bool exist = false;
            for (int i = 0; i < t.columns.Count; i++)
            {
                if (t.extra[i].CompareColumn != string.Empty)
                {
                    if (t.columns[t.columns.FindIndex(c => c.Nom == t.extra[i].CompareColumn)].Null) continue;
                }


                if (!t.columns[i].Null)
                {
                    exist = true;
                    if (t.columns[i].Fk)
                        //
                        nullKeySql.AppendLine($"ALTER TABLE [{ t.tableName }]  ALTER COLUMN[{t.columns[i].Nom}] {revertType(getColumnType(t.columns[i].FKtable, t.columns[i].FKcolumn))}  NOT NULL");
                    else
                        nullKeySql.AppendLine($"ALTER TABLE [{ t.tableName }]  ALTER COLUMN[{t.columns[i].Nom}] {revertType(t.columns[i].Type)}  NOT NULL");

                    //ALTER TABLE[Table] ALTER COLUMN[Column] INTEGER NOT NULL
                }


            }
            if (exist)
                return nullKeySql.ToString();
            else
                return "";
        }
        private static string check(table t)
        {
            StringBuilder checkKeySql = new StringBuilder();
            bool exist = false;
            for (int i = 0; i < t.columns.Count; i++)
            {
                if (t.columns[i].Check)
                {
                    exist = true;

                    if (t.columns[i].CheckOperator == "In")
                        checkKeySql.AppendLine($"ALTER TABLE [{ t.tableName }]  ADD CONSTRAINT ch_{t.tableName}{t.columns[i].Nom} CHECK([{t.columns[i].Nom}] IN {getvalues(t.columns[i].CheckValue1)})");
                    else if (t.columns[i].CheckOperator == "Between")
                        checkKeySql.AppendLine($"ALTER TABLE [{ t.tableName }]  ADD CONSTRAINT ch_{t.tableName}{t.columns[i].Nom} CHECK([{t.columns[i].Nom}] BETWEEN  {t.columns[i].CheckValue1[0]} AND {t.columns[i].CheckValue2})");
                    else if (t.columns[i].CheckOperator == "Column")
                        checkKeySql.AppendLine($"ALTER TABLE [{ t.tableName }]  ADD CONSTRAINT ch_{t.tableName}{t.columns[i].Nom} CHECK([{t.columns[i].Nom}] {t.extra[i].CompareOperator} [{t.extra[i].CompareColumn}])");
                    else
                        checkKeySql.AppendLine($"ALTER TABLE [{ t.tableName }] ADD CONSTRAINT ch_{t.tableName}{t.columns[i].Nom} CHECK([{t.columns[i].Nom}] {t.columns[i].CheckOperator} {t.columns[i].CheckValue1[0]})");

                }


            }
            if (exist)
                return checkKeySql.ToString();
            else
                return "";
        }
        private static string defaultC(table t)
        {
            StringBuilder defaultKeySql = new StringBuilder();
            bool exist = false;
            for (int i = 0; i < t.columns.Count; i++)
            {
                if (t.columns[i].Default)
                {
                    exist = true;
                    if (t.columns[i].Type == "Date")
                        defaultKeySql.AppendLine($"alter table {t.tableName} add constraint df_{t.tableName}{t.columns[i].Nom} default GetDate() for [{t.columns[i].Nom}]");
                    else if (t.columns[i].Type == "String" || t.columns[i].Type == "Char")
                        defaultKeySql.AppendLine($"alter table {t.tableName} add constraint df_{t.tableName}{t.columns[i].Nom} default '{t.columns[i].DefaultValue}' for [{t.columns[i].Nom}]");
                    else
                        defaultKeySql.AppendLine($"alter table {t.tableName} add constraint df_{t.tableName}{t.columns[i].Nom} default {t.columns[i].DefaultValue} for [{t.columns[i].Nom}]");

                }
            }
            if (exist)
                return defaultKeySql.ToString();
            else
                return "";
        }

        #endregion

        #region datasetCreate
        public static void ConvertToDataSet()
        {
            try
            {
                TablesDs = new DataSet(dbname);
                foreach (var table in Tables)
                {
                    var dt = new DataTable(table.tableName);
                    List<DataColumn> primaryKeys = new List<DataColumn>();

                    foreach (var item in table.columns)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = item.Nom;

                        if (item.Identity)
                        {
                            column.AutoIncrement = true;
                            column.AutoIncrementSeed = item.IdentitySeed;
                            column.AutoIncrementStep = item.IdentityStep;
                        }
                        if (item.Null)
                        {
                            column.AllowDBNull = true;
                        }
                        if (item.Unique)
                        {
                            column.Unique = true;
                        }
                        if (item.Default && item.DefaultValue != string.Empty)
                        {
                            column.DefaultValue = item.DefaultValue;
                        }
                        if (item.Primarykey)
                        {
                            primaryKeys.Add(column);
                        }
                        if (item.Type == "Foreign key")
                        {

                            column.DataType = jibtype(getColumnType(item.FKtable, item.FKcolumn));
                        }
                        else
                        {
                            column.DataType = jibtype(item.Type);

                        }

                        dt.Columns.Add(column);

                    }
                    dt.PrimaryKey = primaryKeys.ToArray();
                    TablesDs.Tables.Add(dt);
                }
            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }


        }

        #endregion

        #region datasetRemplissage
        public static void FillDataSetTable(int TableIndex, int nbrfoix)
        {
            var listoflist = new List<dynamic>();
            int FKtracker = 0;
            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            // i couldn't use dictionary ... in the case of the first table contain two pk and the second table contain two column ,
            // both of them fk/pk refrencing the first table columns contiguously 
            List<KeyValuePair<DataTable, string>> fkneeded = new List<KeyValuePair<DataTable, string>>();
            for (int i = 0; i < Tables[TableIndex].columns.Count; i++)
            {
                if (Tables[TableIndex].columns[i].Fk && Tables[TableIndex].columns[i].Primarykey)
                    fkneeded.Add(new KeyValuePair<DataTable, string>(TablesDs.Tables[Tables[TableIndex].columns[i].FKtable], Tables[TableIndex].columns[i].FKcolumn));

            }

            try
            {



                for (int i = 0; i < Tables[TableIndex].columns.Count; i++)
                {


                    //if (Tables[TableIndex].columns[i].Check && Tables[TableIndex].columns[i].CheckValue1 != null)
                    if (Tables[TableIndex].columns[i].Check)
                    {
                        if (Tables[TableIndex].columns[i].CheckOperator == "<")
                        {
                            if (Tables[TableIndex].columns[i].Type == "Int") listoflist.Add(random.shuffleInt((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0]), Tables[TableIndex].columns[i].DefaultValue));
                            if (Tables[TableIndex].columns[i].Type == "Double") listoflist.Add(random.shuffleDouble((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, double.Parse(Tables[TableIndex].columns[i].CheckValue1[0], CultureInfo.InvariantCulture) - 0.1, Tables[TableIndex].extra[i].floatNumber, Tables[TableIndex].columns[i].DefaultValue));
                        }
                        if (Tables[TableIndex].columns[i].CheckOperator == "<=")
                        {
                            if (Tables[TableIndex].columns[i].Type == "Int") listoflist.Add(random.shuffleInt((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0]) + 1, Tables[TableIndex].columns[i].DefaultValue));
                            if (Tables[TableIndex].columns[i].Type == "Double") listoflist.Add(random.shuffleDouble((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, double.Parse(Tables[TableIndex].columns[i].CheckValue1[0], CultureInfo.InvariantCulture), Tables[TableIndex].extra[i].floatNumber, Tables[TableIndex].columns[i].DefaultValue));
                        }
                        if (Tables[TableIndex].columns[i].CheckOperator == ">")
                        {
                            if (Tables[TableIndex].columns[i].Type == "Int") listoflist.Add(random.shuffleInt((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0]) + 100, Tables[TableIndex].columns[i].DefaultValue, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0]) + 1));
                            if (Tables[TableIndex].columns[i].Type == "Double") listoflist.Add(random.shuffleDouble((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, double.Parse(Tables[TableIndex].columns[i].CheckValue1[0], CultureInfo.InvariantCulture) + 100, Tables[TableIndex].extra[i].floatNumber, Tables[TableIndex].columns[i].DefaultValue, double.Parse(Tables[TableIndex].columns[i].CheckValue1[0], CultureInfo.InvariantCulture) + 0.1));
                        }
                        if (Tables[TableIndex].columns[i].CheckOperator == ">=")
                        {
                            if (Tables[TableIndex].columns[i].Type == "Int") listoflist.Add(random.shuffleInt((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0]) + 100, Tables[TableIndex].columns[i].DefaultValue, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0])));
                            if (Tables[TableIndex].columns[i].Type == "Double") listoflist.Add(random.shuffleDouble((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, double.Parse(Tables[TableIndex].columns[i].CheckValue1[0], CultureInfo.InvariantCulture) + 100, Tables[TableIndex].extra[i].floatNumber, Tables[TableIndex].columns[i].DefaultValue, double.Parse(Tables[TableIndex].columns[i].CheckValue1[0], CultureInfo.InvariantCulture)));
                        }
                        if (Tables[TableIndex].columns[i].CheckOperator == "Between")
                        {
                            if (Tables[TableIndex].columns[i].Type == "Int") listoflist.Add(random.shuffleInt((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, int.Parse(Tables[TableIndex].columns[i].CheckValue2), Tables[TableIndex].columns[i].DefaultValue, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0])));
                            if (Tables[TableIndex].columns[i].Type == "Double") listoflist.Add(random.shuffleDouble((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, double.Parse(Tables[TableIndex].columns[i].CheckValue2, CultureInfo.InvariantCulture), Tables[TableIndex].extra[i].floatNumber, Tables[TableIndex].columns[i].DefaultValue, double.Parse(Tables[TableIndex].columns[i].CheckValue1[0], CultureInfo.InvariantCulture)));

                        }
                        if (Tables[TableIndex].columns[i].CheckOperator == "In")
                        {
                            if (Tables[TableIndex].columns[i].Type == "Int")
                            {
                                var listt = new List<int?>();
                                foreach (var item in Tables[TableIndex].columns[i].CheckValue1)
                                {
                                    listt.Add(int.Parse(item));
                                }
                                listoflist.Add(random.In(listt, nbrfoix));

                            }
                            if (Tables[TableIndex].columns[i].Type == "Double")
                            {
                                var listt = new List<double?>();
                                foreach (var item in Tables[TableIndex].columns[i].CheckValue1)
                                {
                                    listt.Add(double.Parse(item, CultureInfo.InvariantCulture));
                                }
                                listoflist.Add(random.In(listt, nbrfoix));

                            }
                            if (Tables[TableIndex].columns[i].Type == "Char")
                            {
                                var listt = new List<char?>();
                                foreach (var item in Tables[TableIndex].columns[i].CheckValue1)
                                {
                                    listt.Add(char.Parse(item));
                                }
                                listoflist.Add(random.In(listt, nbrfoix));
                            }
                            if (Tables[TableIndex].columns[i].Type == "String")
                            {
                                var listt = new List<string>();
                                foreach (var item in Tables[TableIndex].columns[i].CheckValue1)
                                {
                                    listt.Add(item);
                                }
                                listoflist.Add(random.In(listt, nbrfoix));
                            }

                        }
                        if (Tables[TableIndex].columns[i].CheckOperator == "Column" && Tables[TableIndex].extra[i].CompareColumn != string.Empty)
                        {

                            if (Tables[TableIndex].columns[i].Type == "Int") listoflist.Add(random.shuflleListInt((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].extra[i].CompareOperator, listoflist[Tables[TableIndex].columns.FindIndex(c => c.Nom == Tables[TableIndex].extra[i].CompareColumn)]));
                            if (Tables[TableIndex].columns[i].Type == "Double") listoflist.Add(random.shuflleListDouble((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].extra[i].CompareOperator, Tables[TableIndex].extra[i].floatNumber, listoflist[Tables[TableIndex].columns.FindIndex(c => c.Nom == Tables[TableIndex].extra[i].CompareColumn)]));
                            if (Tables[TableIndex].columns[i].Type == "Date") listoflist.Add(random.shuflleListDate((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].extra[i].CompareOperator, listoflist[Tables[TableIndex].columns.FindIndex(c => c.Nom == Tables[TableIndex].extra[i].CompareColumn)]));

                        }






                    }
                    else
                    {
                        if (Tables[TableIndex].columns[i].Type == "Int") listoflist.Add(random.shuffleInt((Tables[TableIndex].columns[i].Unique || (Tables[TableIndex].columns[i].Primarykey && !Tables[TableIndex].columns[i].Identity)), Tables[TableIndex].columns[i].Null, nbrfoix, nbrfoix + 100, Tables[TableIndex].columns[i].DefaultValue));
                        if (Tables[TableIndex].columns[i].Type == "Double") listoflist.Add(random.shuffleDouble((Tables[TableIndex].columns[i].Unique || (Tables[TableIndex].columns[i].Primarykey && !Tables[TableIndex].columns[i].Identity)), Tables[TableIndex].columns[i].Null, nbrfoix, nbrfoix + 100, Tables[TableIndex].extra[i].floatNumber, Tables[TableIndex].columns[i].DefaultValue));
                        if (Tables[TableIndex].columns[i].Type == "Char") listoflist.Add(random.shuffleChar((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, Tables[TableIndex].columns[i].DefaultValue, Tables[TableIndex].extra[i].charMode));
                        if (Tables[TableIndex].columns[i].Type == "Date") listoflist.Add(random.shuffleDate((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, Tables[TableIndex].extra[i].dateDebut, Tables[TableIndex].extra[i].dateFin));
                        if (Tables[TableIndex].columns[i].Type == "Bool") listoflist.Add(random.shuffleBool(nbrfoix, Tables[TableIndex].columns[i].Null));
                        if (Tables[TableIndex].columns[i].Type == "String" && Tables[TableIndex].extra[i].ChoixCategorie.Count == 0) listoflist.Add(random.shuffleString(Tables[TableIndex].columns[i].Null, Tables[TableIndex].columns[i].Nom, Tables[TableIndex].columns[i].DefaultValue, nbrfoix));
                        if (Tables[TableIndex].columns[i].Type == "String" && Tables[TableIndex].extra[i].ChoixCategorie.Count > 0) listoflist.Add(random.shuffleChoix(Tables[TableIndex].extra[i].ChoixCategorie, nbrfoix, (Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, Tables[TableIndex].columns[i].DefaultValue));
                        if (Tables[TableIndex].columns[i].Type == "Time") listoflist.Add(random.shuffleTime((Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix));
                        if (Tables[TableIndex].columns[i].Type == "Foreign key" && !Tables[TableIndex].columns[i].Primarykey) listoflist.Add(foreignkey(TablesDs.Tables[Tables[TableIndex].columns[i].FKtable], Tables[TableIndex].columns[i].FKcolumn, nbrfoix));
                        if (Tables[TableIndex].columns[i].Type == "Foreign key" && Tables[TableIndex].columns[i].Primarykey) listoflist.Add(FKtracker++);

                    }


                }

                StringBuilder sb = new StringBuilder();

                //table with only one identity column
                Tables[TableIndex].insert.Clear();

                if (TablesDs.Tables[TableIndex].Columns.Count == 1 && TablesDs.Tables[TableIndex].PrimaryKey.Contains(TablesDs.Tables[TableIndex].Columns[0]) && TablesDs.Tables[TableIndex].Columns[0].AutoIncrement)
                {
                    for (int i = 0; i < nbrfoix; i++)
                    {
                        TablesDs.Tables[TableIndex].Rows.Add(TablesDs.Tables[TableIndex].NewRow());
                        sb.AppendLine($"INSERT INTO {TablesDs.Tables[TableIndex].TableName} DEFAULT VALUES");
                    }
                }
                else
                {

                    int[][] FKwithPK = null;
                    if (fkneeded.Count > 0)
                        FKwithPK = random.damn(nbrfoix, fkneeded);



                    for (int i = 0; i < nbrfoix; i++)
                    {
                        sb.Append($"INSERT INTO [{TablesDs.Tables[TableIndex].TableName}] VALUES (");

                        var row = TablesDs.Tables[TableIndex].NewRow();
                        for (int j = 0; j < TablesDs.Tables[TableIndex].Columns.Count; j++)
                        {
                            if (Tables[TableIndex].columns[j].Fk && Tables[TableIndex].columns[j].Primarykey)
                            {
                                row[j] = FKwithPK[i][listoflist[j]];
                                sb.Append($"{FKwithPK[i][listoflist[j]]} ,");
                            }
                            else if (TablesDs.Tables[TableIndex].PrimaryKey.Contains(TablesDs.Tables[TableIndex].Columns[j]) && TablesDs.Tables[TableIndex].Columns[j].AutoIncrement) continue;
                            else if (listoflist[j][i] == null)
                            {
                                row[j] = DBNull.Value;
                                sb.Append("null ,");
                            }
                            else if (TablesDs.Tables[TableIndex].Columns[j].DataType == typeof(DateTime))
                            {
                                if (Tables[TableIndex].columns[j].Default)
                                {
                                    row[j] = DateTime.Now.Date;
                                    sb.Append($" getDate() ,");
                                }
                                else
                                {
                                    row[j] = listoflist[j][i];
                                    sb.Append($"'{listoflist[j][i].ToString("yyyy-MM-dd")}' ,");
                                }
                            }
                            else
                            {
                                row[j] = listoflist[j][i];
                                if (TablesDs.Tables[TableIndex].Columns[j].DataType == typeof(string))
                                {
                                    sb.Append($"'{escapeCharachterString(listoflist[j][i])}' ,");

                                }
                                else if (TablesDs.Tables[TableIndex].Columns[j].DataType == typeof(char))
                                {
                                    sb.Append($"'{escapeCharachterchar(listoflist[j][i])}' ,");
                                }
                                else if (TablesDs.Tables[TableIndex].Columns[j].DataType != typeof(int) && TablesDs.Tables[TableIndex].Columns[j].DataType != typeof(double))
                                {

                                    sb.Append($"'{listoflist[j][i]}' ,");
                                }
                                else if (TablesDs.Tables[TableIndex].Columns[j].DataType == typeof(double))
                                {

                                    sb.Append($"{listoflist[j][i].ToString(nfi)} ,");
                                }
                                else

                                    sb.Append($"{listoflist[j][i]} ,");

                            }

                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.AppendLine(")");
                        TablesDs.Tables[TableIndex].Rows.Add(row);
                    }
                }


                Tables[TableIndex].insert.Add(sb.ToString());
            }
            catch (Exception m)
            {

                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();
            }

        }
        #endregion
        private static string escapeCharachterString(dynamic d)
        {
            string s = (string)d;
            return s.Replace("'", "''");
        }
        private static string escapeCharachterchar(dynamic d)
        {
            string c = ((char)d).ToString();
            return c.Replace("'", "''");
        }
    }
}
