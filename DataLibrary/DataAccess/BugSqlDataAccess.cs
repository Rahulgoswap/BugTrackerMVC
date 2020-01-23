using Dapper;
using DataLibrary.Analytics;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public static class BugSqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "MVCDemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();

            }
        }
        

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {

                return cnn.Execute(sql, data);

            }

        }
        public static List<T> LoadData2<T>(T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {


                return cnn.Query<T>("UpdateAction", data, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public static List<BugModel> DataRemove(int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {


                return cnn.Query<BugModel>("select * from dbo.BugRecords "+ "where Id ="+id, new { id } ).ToList();

            }


        }
        public static int SqlRemove(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql);

            }

        }

        public static List<BugModel> SqlFetch(string sql)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<BugModel>(sql).ToList();
            }
        }

        public static List<AnalyticsModel> SqlStat(string sql)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<AnalyticsModel>(sql).ToList();
            }
        }
    }
}
