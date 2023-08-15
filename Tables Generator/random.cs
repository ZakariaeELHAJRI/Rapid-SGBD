using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables_Generator
{
    class random
    {

        private static Random rand = new Random();
        //public static List<int?> shuffleInt(Column C,int nbrfoix)
        //{
            //(Tables[TableIndex].columns[i].Unique || Tables[TableIndex].columns[i].Primarykey), Tables[TableIndex].columns[i].Null, nbrfoix, int.Parse(Tables[TableIndex].columns[i].CheckValue1[0]), Tables[TableIndex].columns[i].DefaultValue
            //(bool unique, bool Null, int nbrfoix, int max, string defolt, int min = 0)
            //int number;
            //bool unique = C.Unique || C.Primarykey;
            //bool Null = C.Null;
            //int max = int.Parse(C.CheckValue1[0]);
            //int min = ()
            //string defolt = C.DefaultValue;   
        //}
        public static List<int?> shuffleInt(bool unique, bool Null, int nbrfoix, int max, string defolt, int min = 0)
        {
            int number;

            List<int?> listNumbers = new List<int?>();

            if (max == 0) max = 100;

            if (unique)
            {
                // numbers kter mn range o unique ?? cavapa
                if ((nbrfoix - min) < nbrfoix) throw new Exception("impossible de donner ce nombre int unique de donner");
                if (min > max) throw new InvalidOperationException("min > max");

                for (int i = 0; i < nbrfoix; i++)
                {
                    do
                    {
                        number = rand.Next(min + 1, nbrfoix + 1);
                    } while (listNumbers.Contains(number));
                    listNumbers.Add(number);
                }
            }
            else
            {
                for (int i = 0; i < nbrfoix; i++)
                {

                    listNumbers.Add(rand.Next(min, max));
                }
            }
            if (defolt != string.Empty)
            {
                int x;
                if (int.TryParse(defolt, out x))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (rand.NextDouble() > 0.6) listNumbers[rand.Next(listNumbers.Count)] = x;
                    }
                }
                else throw new Exception($"cannot use [{defolt}] as default int value");


            }
            if (Null) nullable(ref listNumbers);

            return listNumbers;
        }
        public static List<double?> shuffleDouble(bool unique, bool Null, int nbrfoix, double max, int precision,string defolt, double min = 0)
        {
            double number;
            List<double?> listdouble = new List<double?>();
            if (max == 0) max = 100;

            if (unique)
            {

                //     if ((max - min) < nbrfoix) return;  mathtajch had check
                if (min > max) throw new InvalidOperationException("min > max");

                for (int i = 0; i < nbrfoix; i++)
                {
                    do
                    {
                        number = Math.Round(rand.NextDouble() * (max - min) + min, precision);
                    } while (listdouble.Contains(number));
                    listdouble.Add(number);
                }
            }
            else
            {
                for (int i = 0; i < nbrfoix; i++)
                {

                    number = Math.Round(rand.NextDouble() * (max - min) + min, precision);
                    listdouble.Add(number);
                }
            }
            if (defolt != string.Empty)
            {
                double x;
                if (Double.TryParse(defolt, out x))
                {
                    x = Math.Round(x, precision);
                    for (int i = 0; i < 10; i++)
                    {
                        if (rand.NextDouble() > 0.6) listdouble[rand.Next(listdouble.Count)] = x;
                    }
                }
                else throw new Exception($"cannot use [{defolt}] as default Double value");


            }
            if (Null) nullable(ref listdouble);

            return listdouble;
        }
        public static List<char?> shuffleChar(bool unique, bool Null, int nbrfoix,string defolt, int weirdShit = 0)
        {

            var Operator = new int[] { 42, 43, 45, 47, 37 };
            var miniscule = Enumerable.Range(97, 25).ToArray();
            var majescule = Enumerable.Range(65, 25).ToArray();
            var numbers = Enumerable.Range(48, 9).ToArray();
            var all = Enumerable.Range(33, 93).Except(majescule).ToArray();
            var symbol = all.Except(Operator).Except(miniscule).Except(majescule).Except(numbers).ToArray();
            int[] choice;
            switch (weirdShit)
            {
                case 0: choice = miniscule; break;
                case 1: choice = majescule; break;
                case 2: choice = numbers; break;
                case 3: choice = Operator; break;
                case 4: choice = symbol; break;
                case 5: choice = all; break;
                default:
                    throw new Exception("erreeur char selection!!");

            }
            char x;
            List<char?> listchars = new List<char?>();

            if (unique)
            {
                if (nbrfoix > choice.Length) throw new InvalidOperationException(" impossible de donner ce nombre de  unique characters ");


                for (int i = 0; i < nbrfoix; i++)
                {
                    do
                    {
                        x = Convert.ToChar(choice[rand.Next(choice.Length)]);
                    } while (listchars.Contains(x));
                    listchars.Add(x);
                }
            }
            else
            {
                for (int i = 1; i <= nbrfoix; i++)
                {

                    listchars.Add(Convert.ToChar(choice[rand.Next(choice.Length)]));
                }
            }
            if (defolt != string.Empty)
            {
                char c;
                if (char.TryParse(defolt, out c))
                {
               
                    for (int i = 0; i < 10; i++)
                    {
                        if (rand.NextDouble() > 0.6) listchars[rand.Next(listchars.Count)] = c;
                    }
                }
                else throw new Exception($"cannot use [{defolt}] as default char value");


            }
            if (Null)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) listchars[rand.Next(listchars.Count)] = null;
                }

            return listchars;
        }
        public static List<DateTime?> shuffleDate(bool unique, bool Null, int nbrfoix, DateTime start, DateTime end)
        {
            List<DateTime?> listdate = new List<DateTime?>();
            var span = (end.Date - start.Date).Days;
            DateTime date;

            if (unique)
            {

                if (nbrfoix > span) throw new Exception("impossible de donner ce nombre unique de donner");
                if (start > end) throw new InvalidOperationException("Date Debut Must be less than Date Fin");

                for (int i = 0; i < nbrfoix; i++)
                {
                    do
                    {
                        date = start.AddDays(rand.Next(span + 1)).Date;//bach yt3jen hadchi mzn hh
                    } while (listdate.Contains(date));
                    listdate.Add(date.Date);
                }
            }
            else
            {
                for (int i = 0; i < nbrfoix; i++)
                {

                    listdate.Add(start.AddDays(rand.Next(span + 1)).Date);
                }
            }
            if (Null) nullable(ref listdate);

            return listdate;
        }
        public static List<string> shuffleTime(bool unique, bool Null, int nbrfoix)
        {
            List<string> listtime = new List<string>();

            string time;

            if (unique)
            {


                for (int i = 0; i < nbrfoix; i++)
                {
                    do
                    {
                        time = $"{rand.Next(24)}:{ rand.Next(60)}:{ rand.Next(60)}";
                    } while (listtime.Contains(time));
                    listtime.Add(time);
                }
            }
            else
            {
                for (int i = 0; i < nbrfoix; i++)
                {
                    time = $"{rand.Next(24)}:{ rand.Next(60)}:{ rand.Next(60)}";
                    listtime.Add(time);
                }
            }
            if (Null)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) listtime[rand.Next(listtime.Count)] = null;
                }
            return listtime;

        }
        public static List<bool?> shuffleBool(int nbrfoix, bool Null)
        {
            List<bool?> listboolean = new List<bool?>();
            for (int i = 0; i < nbrfoix; i++)
            {
                if (rand.NextDouble() > 0.5) listboolean.Add(false);
                else listboolean.Add(true);
            }
            if (Null) nullable(ref listboolean);

            return listboolean;
        }
        public static List<string> shuffleString(bool unique, bool Null, string Default, int nbrfoix)
        {

            List<string> liststring = new List<string>();

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";


            if (unique)
            {

                for (int i = 0; i < nbrfoix; i++)
                {
                    var stringChars = new char[rand.Next(2, 10)];
                    do
                    {
                        for (int j = 0; j < stringChars.Length; j++)
                        {
                            stringChars[j] = chars[rand.Next(chars.Length)];
                        }

                    } while (liststring.Contains(new string(stringChars)));
                    liststring.Add(new string(stringChars));
                }
            }
            else
            {
                for (int i = 0; i < nbrfoix; i++)
                {
                    var stringChars = new char[rand.Next(2, 10)];
                    for (int j = 0; j < stringChars.Length; j++)
                    {
                        stringChars[j] = chars[rand.Next(chars.Length)];
                    }


                    liststring.Add(new string(stringChars));
                }

            }

            if (Default != string.Empty)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) liststring[rand.Next(liststring.Count)] = Default;
                }
            else if (Null)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) liststring[rand.Next(liststring.Count)] = null;
                }

            return liststring;

        }
        public static List<string> shuffleString(bool Null, string colName, string Default, int nbrfoix)
        {
            List<string> liststring = new List<string>();
            for (int i = 0; i < nbrfoix; i++)
            {
                liststring.Add(colName + (i + 1));
            }
            if (Default != string.Empty)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) liststring[rand.Next(liststring.Count)] = Default;
                }
            else if (Null)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) liststring[rand.Next(liststring.Count)] = null;
                }

            return liststring;
        }
        public static List<string> shuffleChoix(List<string> choix, int nbrfoix, bool unique, bool Null, string Default)
        {
            var shuffledList = new List<string>();
            string x;

            if (unique)
            {

                if (nbrfoix > choix.Count) throw new InvalidOperationException($"imposible de donner ce nombre unique car categorie contient{choix.Count} ");
                for (int i = 0; i < nbrfoix; i++)
                {

                    do
                    {
                        x = choix[rand.Next(choix.Count)];


                    } while (shuffledList.Contains(x));
                    shuffledList.Add(x);

                }
            }
            else
            {
                for (int i = 0; i < nbrfoix; i++)
                {
                    shuffledList.Add(choix[rand.Next(choix.Count)]);
                }

            }

            if (Default != string.Empty)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) shuffledList[rand.Next(shuffledList.Count)] = Default;
                }
            else if (Null)
                for (int i = 0; i < 10; i++)
                {
                    if (rand.NextDouble() > 0.6) shuffledList[rand.Next(shuffledList.Count)] = null;
                }
            return shuffledList;
        }
        public static List<T?> In<T>(List<T?> x, int nbrfoix) where T:struct
        {
            var y = new List<T?>();

            for (int i = 0; i < nbrfoix; i++)
            {
                y.Add(x[rand.Next(x.Count)].Value);
            }
            return y;
        }
        public static List<T> In<T>(List<T> x, int nbrfoix) 
        {
            var y = new List<T>();

            for (int i = 0; i < nbrfoix; i++)
            {
                y.Add(x[rand.Next(x.Count)]);
            }
            return y;
        }
        private static void nullable<T>(ref List<T?> list) where T : struct
        {
            for (int i = 0; i < 10; i++)
            {
                if (rand.NextDouble() > 0.6) list[rand.Next(list.Count)] = null;
            }

        }



        public static int[][] damn(int nbrfoix, List<KeyValuePair<DataTable, string>> tables)
        {
            int limiter = 1;
            var keys = new int[tables.Count][];
            int count = 0;


            foreach (KeyValuePair<DataTable, string> item in tables)
            {
                limiter *= item.Key.Rows.Count;

                keys[count] = new int[item.Key.Rows.Count];
                int column = item.Key.Columns.IndexOf(item.Value);
                for (int k = 0; k < item.Key.Rows.Count; k++)
                {
                    keys[count][k] = item.Key.Rows[k].Field<int>(column);
                }
                count++;
            }

            if (nbrfoix > limiter) throw new InvalidOperationException("impossible de générer ce nombre des cas \n le maximum est " + limiter);
            List<int[]> waw = new List<int[]>();
            for (int i = 0; i < nbrfoix; i++)
            {
                //must be reinitialized  because arrays are referencs type , any change will also affect the list
                int[] temp = new int[tables.Count];
                do
                {
                    for (int j = 0; j < tables.Count; j++)
                    {
                        temp[j] = keys[j][rand.Next(keys[j].Length)];
                    }

                } while (arrayCompare(waw, temp));
                waw.Add(temp);

            }

            return waw.ToArray();


        }
        private static bool arrayCompare(List<int[]> source, int[] New)
        {
            foreach (var item in source)
            {
                if (item.SequenceEqual(New)) return true;
            }
            return false;
        }


        #region methodLherba
        // produce int,double,char,date
        //public static List<T?> shuffle<T>(bool unique, bool Null, int nbrfoix, int max = 1, int min = 0, int precision = 2, int mode = 5, DateTime? start = null, DateTime? end = null) where T : struct
        //{
        //    if (min > max) throw new InvalidOperationException();
        //    List<T?> listNumbers = new List<T?>();
        //    Type itemType = typeof(T);
        //    dynamic number;
        //    int[] choice = null;


        //    if (itemType == typeof(char))
        //    {
        //        var Operator = new int[] { 42, 43, 45, 47, 37 };
        //        var miniscule = Enumerable.Range(97, 25).ToArray();
        //        var majescule = Enumerable.Range(65, 25).ToArray();
        //        var numbers = Enumerable.Range(48, 9).ToArray();
        //        var all = Enumerable.Range(33, 93).ToArray();
        //        var symbol = all.Except(Operator).Except(miniscule).Except(majescule).Except(numbers).ToArray();
        //        switch (mode)
        //        {
        //            case 0: choice = miniscule; break;
        //            case 1: choice = majescule; break;
        //            case 2: choice = numbers; break;
        //            case 3: choice = Operator; break;
        //            case 4: choice = symbol; break;
        //            case 5: choice = all; break;

        //            default:
        //                throw new Exception("erreeur !!");

        //        }
        //    }

        //    if (unique)
        //    {
        //        if ((nbrfoix - min) < nbrfoix && (itemType == typeof(int) || itemType == typeof(double))) throw new Exception("impossible de donner ce nombre de int unique de donner");
        //        if (choice != null)
        //            if (nbrfoix > choice.Length && itemType == typeof(char)) throw new InvalidOperationException(" impossible de donner ce nombre de char unique characters ");
        //        if (start.HasValue && end.HasValue)
        //            if (nbrfoix > (start.Value.Date - end.Value.Date).Days && itemType == typeof(DateTime)) throw new Exception("impossible de donner ce nombre date unique de donner");


        //        for (int i = 0; i < nbrfoix; i++)
        //        {
        //            do
        //            {
        //                if (itemType == typeof(int))
        //                    number = rand.Next(min + 1, nbrfoix + 1);
        //                else if (itemType == typeof(char))
        //                    number = Convert.ToChar(choice[rand.Next(choice.Length)]);
        //                else if (itemType == typeof(DateTime))
        //                    number = start.Value.AddDays(rand.Next(0, (end.Value.Date - start.Value.Date).Days) + 1).Date;

        //                else
        //                    number = Math.Round(rand.NextDouble() * (max - min) + min, precision);


        //            } while (listNumbers.Contains(number));
        //            listNumbers.Add(number);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < nbrfoix; i++)
        //        {

        //            if (itemType == typeof(int))
        //                number = rand.Next(min, max);
        //            else if (itemType == typeof(char))
        //                number = Convert.ToChar(choice[rand.Next(choice.Length)]);
        //            else if (itemType == typeof(DateTime))
        //                number = start.Value.AddDays(rand.Next((end.Value.Date - start.Value.Date).Days) + 1).Date;

        //            else
        //                number = Math.Round(rand.NextDouble() * (max - min) + min, precision);

        //            listNumbers.Add(number);
        //        }

        //    }
        //    if (Null) nullable(ref listNumbers);
        //    return listNumbers;

        //}
        #endregion

        public static List<int?> shuflleListInt(bool unique, string Operator, List<int?> source)
        {
            var result = new List<int?>();
            int x;
            if (unique)
            {
                switch (Operator)
                {
                    case ">":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                do
                                {
                                    x = rand.Next(source[i].Value + 1, source[i].Value + 100);
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case ">=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                do
                                {
                                    x = rand.Next(source[i].Value, source[i].Value + 100);
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case "<=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                do
                                {
                                    x = rand.Next(0, source[i].Value+1);
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case "<":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                do
                                {
                                    x = rand.Next(0, source[i].Value );
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    default:
                        break;
                }

            }
            else
            {
                switch (Operator)
                {
                    case ">":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(rand.Next(source[i].Value + 1, source[i].Value + 100));
                            }
                            else result.Add(null);
                        }; break;
                    case ">=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(rand.Next(source[i].Value, source[i].Value + 100));
                            }
                            else result.Add(null);
                        }; break;
                    case "<=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(rand.Next(0, source[i].Value));
                            }
                            else result.Add(null);
                        }; break;
                    case "<":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(rand.Next(0, source[i].Value ));
                            }
                            else result.Add(null);
                        }; break;
                    default:
                        break;
                }


            }
            return result;
        }
        public static List<double?> shuflleListDouble(bool unique, string Operator, int precision, List<double?> source)
        {
            var result = new List<double?>();
            double x;
            if (unique)
            {
                switch (Operator)
                {
                    case ">":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                do
                                {
                                    double max = source[i].Value + 100;
                                    x = Math.Round(rand.NextDouble() * (max - source[i].Value + 0.1) + source[i].Value, precision);
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case ">=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                do
                                {
                                    double max = source[i].Value + 100;
                                    x = Math.Round(rand.NextDouble() * (max - source[i].Value) + source[i].Value, precision);
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case "<=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                do
                                {
                                    x = Math.Round(rand.NextDouble() * source[i].Value, precision);
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case "<":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                do
                                {
                                    x = Math.Round(rand.NextDouble() * source[i].Value - 0.1, precision);
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    default:
                        break;
                }


            }
            else
            {
                switch (Operator)
                {
                    case ">":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                double max = source[i].Value + 100;

                                result.Add(Math.Round(rand.NextDouble() * (max - source[i].Value + 0.1) + source[i].Value, precision));
                            }
                            else result.Add(null);
                        }; break;
                    case ">=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                double max = source[i].Value + 100;

                                result.Add(Math.Round(rand.NextDouble() * (max - source[i].Value) + source[i].Value, precision));
                            }
                            else result.Add(null);
                        }; break;
                    case "<=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(Math.Round(rand.NextDouble() * source[i].Value, precision));
                            }
                            else result.Add(null);
                        }; break;
                    case "<":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                result.Add(Math.Round(rand.NextDouble() * source[i].Value - 0.1, precision));
                            }
                            else result.Add(null);
                        }; break;
                    default:
                        break;
                }

            }
            return result;
        }
        public static List<DateTime?> shuflleListDate(bool unique, string Operator, List<DateTime?> source)
        {
            var result = new List<DateTime?>();
            DateTime x;
            if (unique)
            {
                switch (Operator)
                {
                    case ">":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                do
                                {
                                    x = source[i].Value.AddDays(rand.Next(1, source.Count));
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case ">=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                do
                                {
                                    x = source[i].Value.AddDays(rand.Next(0, source.Count));
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case "<=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                do
                                {
                                    x = source[i].Value.AddDays(-rand.Next(source.Count));
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    case "<":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                do
                                {
                                    x = source[i].Value.AddDays(-rand.Next(1, source.Count));
                                } while (result.Contains(x));
                                result.Add(x);
                            }
                            else result.Add(null);
                        }; break;
                    default:
                        break;
                }


            }
            else
            {
                switch (Operator)
                {
                    case ">":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(source[i].Value.AddDays(rand.Next(1, source.Count)));
                            }
                            else result.Add(null);
                        }; break;
                    case ">=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(source[i].Value.AddDays(rand.Next(source.Count)));
                            }
                            else result.Add(null);
                        }; break;
                    case "<=":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {

                                result.Add(source[i].Value.AddDays(-rand.Next(source.Count)));
                            }
                            else result.Add(null);
                        }; break;
                    case "<":
                        for (int i = 0; i < source.Count; i++)
                        {
                            if (source[i].HasValue)
                            {
                                result.Add(source[i].Value.AddDays(-rand.Next(1, source.Count)));
                            }
                            else result.Add(null);
                        }; break;
                    default:
                        break;
                }


            }
            return result;
        }

    }
}
