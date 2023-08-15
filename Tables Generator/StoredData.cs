using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using Tables_Generator.Properties;

namespace Tables_Generator
{
    public static class StoredData
    {
        public static List<Categorie> categoriesContainer = new List<Categorie>();
        public static bool backgroundTaskRunning = false;

        #region AddCategorie(string categoryName) //return true when Added  
        public static bool AddCategory(string categoryName)  
        {
            bool contains = false;
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name == categoryName) contains = true;
            }
            if (contains || categoryName.Trim() == string.Empty) return false;
            else 
            {
                StoredData.categoriesContainer.Add(new Categorie(categoryName));
                return true;
            }
        }
        #endregion

        #region AddCategorie(string categoryName, Bitmap categoryPicture) //return true when Added
        public static bool AddCategory(string categoryName, Bitmap categoryPicture)
        {
            bool contains = false;
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name == categoryName) contains = true;
            }
            if (contains || categoryName.Trim() == string.Empty) return false;
            else
            {
                StoredData.categoriesContainer.Add(new Categorie(categoryName, categoryPicture));
                return true;
            }
        }
        #endregion

        #region RenameCategory //Return true when Edited
        public static bool RenameCategory(string categoryName, string newName)
        {
            #region case InvalideName() //Name of an other Category
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name.ToUpper() == newName.Trim().ToUpper()) return false;
            }
            #endregion

            #region case valideName()
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name == categoryName)
                {
                    X.Name = newName;
                    break;
                }
            }
            return true;
            #endregion
        }
        #endregion

        #region AddToCategory //return true when Added
        public static bool AddToCategory(string categoryName, string value) 
        {
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name == categoryName)
                {
                    if (!X.Data.Contains(value))
                    {
                        X.Data.Add(value);
                        X.Data.Sort();
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region SortCategories
        public static void SortCategories() 
        {
            StoredData.categoriesContainer.Sort((X, Y) => String.Compare(X.Name, Y.Name));
        }
        #endregion

        #region CategoryCount
        public static int CategoryCount(string categoryName)
        {
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name ==categoryName)
                {
                    return X.Data.Count;
                }
            }
            return 0;
        }
        #endregion

        #region DeleteCategory //return true when Deleted
        public static bool DeleteCategory (string categoryName)
        {
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name == categoryName)
                {
                    StoredData.categoriesContainer.Remove(X);
                    return true;
                }
            }            
            return false;
        }
        #endregion

        #region DeleteFromCategory //return true when Deleted
        public static bool DeleteFromCategory(string categoryName, string value)
        {
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name == categoryName)
                {
                    if (X.Data.Contains(value))
                    {
                        X.Data.Remove(value);
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region DataSource
        public static List<string> DataSource(string categoryName) 
        {
            foreach(Categorie X in StoredData.categoriesContainer) 
            {
                if(X.Name == categoryName) 
                {
                    return X.Data;
                }
            }
            return null;
        }
        #endregion

        #region Serialize
        public static void Serialize()
        {
            string directoryPath = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Tables Generator";
            string objectPath = directoryPath + @"\SavedCategories";
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            if (!dir.Exists) dir.Create();
            if (File.Exists(objectPath)) File.Delete(objectPath);

            FileStream fileStream = new FileStream(objectPath, FileMode.CreateNew);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream , StoredData.categoriesContainer);
            fileStream.Close();
        }
        #endregion

        #region Deserialize
        public static void Deserialize()
        {
            string directoryPath = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Tables Generator";
            string objectPath = directoryPath + @"\SavedCategories";
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            if (!dir.Exists) dir.Create();
            if (!File.Exists(objectPath)) return;

            FileStream fileStream = new FileStream(objectPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
            StoredData.categoriesContainer = (List<Categorie>)binaryFormatter.Deserialize(fileStream);            
            }
            finally
            {
                fileStream.Close();
            }
            
        }
        #endregion

        #region FirstTimeUse()
        public static void FirstTimeUse()
        {
            if ((bool)Settings.Default["FirstTimeUse"] == true)
            {
                GenerateData.AddDefaultCategories();
                GenerateData.FillDefaultCategories();
                GenerateData.NotifyUser();                
                Settings.Default["FirstTimeUse"] = false;
                Settings.Default.Save();
            }
        }
        #endregion

    }
}
