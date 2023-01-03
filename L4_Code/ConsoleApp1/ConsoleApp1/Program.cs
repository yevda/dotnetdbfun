
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var paramList = new[] {
            //    new Microsoft.Data.SqlClient.SqlParameter("@year", 2020),
            //    new Microsoft.Data.SqlClient.SqlParameter()
            //    {
            //        ParameterName = "@total",
            //        SqlDbType = System.Data.SqlDbType.Int,
            //        Direction = System.Data.ParameterDirection.Output
            //    },
            //                    };


            try
            {
                SqlConnection cnn;
                string connectionString = @"Server=SSW-WSA-9220;Database=AdventureWorks2019;Trusted_Connection=True;TrustServerCertificate=True";
                cnn = new SqlConnection(connectionString);
                var command = new SqlCommand("EXECUTE [HumanResources].[uspGetEmployeesKhai] 291, @SName OUT;", cnn);
                command.Parameters.Add("SName", SqlDbType.NVarChar).Value = "SName";
                //var command = new SqlCommand("SELECT * FROM [dbo].[GetEmployeesByIdKhai] (5);", cnn);

                var myvar = 0;
                cnn.Open();
                var res = command.ExecuteNonQuery();
                cnn.Close();
                Console.WriteLine(res);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                //throw;
            }
            
      


            //MyDBContext db = new MyDBContext();

            //Console.WriteLine("Hello, World!");
            //var par_output = new Microsoft.Data.SqlClient.SqlParameter();
            //db.Database.ExecuteSqlInterpolated($"EXECUTE [HumanResources].[uspGetEmployeesKhai] 5, @SName OUT;");



        }
    }
}