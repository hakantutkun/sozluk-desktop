using Dapper;
using SozlukDesktop.Entities.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SozlukDesktop.DBAccess.Manager
{
    /// <summary>
    /// Default summary for DBManager.cs
    /// </summary>
    public class DBManager
    {

        #region Helper Functions

        /// <summary>
        /// Loads words from database with given string value
        /// </summary>
        /// <param name="s">Given string value</param>
        /// <returns>List of <see cref="Kelime"/></returns>
        public static List<Kelime> LoadWordsLike(string s)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.Query<Kelime>("select * from t_kelime where KaracaycaAnlam like '" + s +"%'", new DynamicParameters()).ToList();
            }
        }

        /// <summary>
        /// Loads all words from database
        /// </summary>
        /// <returns>List of words</returns>
        public static List<Kelime> LoadAllWords()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.Query<Kelime>("select * from t_kelime", new DynamicParameters()).ToList();
            }
        }

        /// <summary>
        /// Loads all examples from database
        /// </summary>
        /// <returns>List of examples</returns>
        public static List<Ornek> LoadAllExamples()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.Query<Ornek>("select * from t_ornek", new DynamicParameters()).ToList();
            }
        }

        /// <summary>
        /// Loads the default connection string
        /// </summary>
        /// <param name="id">connectionstring id</param>
        /// <returns>ConnectionString</returns>
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        #endregion

    }
}
