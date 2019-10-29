// <copyright file="DataBaseLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class DataBaseLogger : ILogger
    {
        public string StringConnection { get; set; } = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();

        public void ReadMessage()
        {
            string sqlExpression = "sp_GetLogs";

            using (SqlConnection connection = new SqlConnection(this.StringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string exception = reader.GetString(1);
                        Console.WriteLine("{0} \t{1}", id, exception);
                    }
                }

                reader.Close();
            }
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
                    Value = e.Message,
                };
                command.Parameters.Add(exceptionParams);
                var result = command.ExecuteScalar();
                ////result = command.ExecuteNonQuery();
                Console.WriteLine("Id addedd object: {0}", result);
            }
        }
    }
}
////CREATE PROCEDURE[dbo].[sp_InsertLogMessages]
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