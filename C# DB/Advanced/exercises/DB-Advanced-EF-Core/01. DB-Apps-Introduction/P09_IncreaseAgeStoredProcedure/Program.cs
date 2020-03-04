using System;
using System.Data;
using System.Data.SqlClient;

namespace P09_IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            // create procedure text (run in Sql Server Management Studio)
            //CREATE PROC usp_GetOlder(@minionId INT)
            //AS
            //    UPDATE Minions
            //    SET Age += 1

            //    WHERE Id = @minionId

            int minionId = int.Parse(Console.ReadLine());

            string connectionString = "Server=(localdb)\\v12.0;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            connection.Open();
            using (connection)
            {
                var updateAgeCommand = new SqlCommand("usp_GetOlder", connection) { CommandType = CommandType.StoredProcedure };
                updateAgeCommand.Parameters.AddWithValue("@minionId", minionId);
                updateAgeCommand.ExecuteNonQuery();

                // get minion info

                string getMinionInfoQuery = "SELECT CONCAT(Name, ' - ', Age, ' years old') FROM Minions WHERE Id = @minionId";
                var getMinionInfoCommand = new SqlCommand(getMinionInfoQuery, connection);
                getMinionInfoCommand.Parameters.AddWithValue("@minionId", minionId);

                var reader = getMinionInfoCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                }
                reader.Close();
            }
        }
    }
}
