using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
   public class DataBaseLogger : ILogger
    {
        string StringConnection { get; set; } = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();

        public void ReadMessage()
        {
        }

        public void WriteMessage(Exception e)
        {
            string sqlExpression = "sp_InsertLogMessages";

            using (SqlConnection connection = new SqlConnection(this.StringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter exceptionParams = new SqlParameter
                {
                    ParameterName = "@ExeptionMessage",
                    Value = e.Message
                };
                command.Parameters.Add(exceptionParams);
                var result = command.ExecuteScalar();
                ////var result = command.ExecuteNonQuery();
                Console.WriteLine("Id addedd object: {0}", result);
            }
        }
    }
}
////CREATE PROCEDURE[dbo].[sp_InsertLogMessage]
////@ExeptionMessage nvarchar(255),
////    @age int
////AS
////    INSERT INTO Log(ExeptionMessage)
////    VALUES(@ExeptionMessage)


////    SELECT SCOPE_IDENTITY()
////GO
////CREATE PROCEDURE[dbo].[sp_GetLogs]
////AS
////    SELECT* FROM Log
////GO