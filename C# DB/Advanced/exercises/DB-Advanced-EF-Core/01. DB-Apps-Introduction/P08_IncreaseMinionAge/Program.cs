using System;
using System.Data.SqlClient;
using System.Linq;

namespace P08_IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\v12.0;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            int[] minionIds = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();

            connection.Open();
            using (connection)
            {
                string updateQuery = @"UPDATE Minions
                                    SET Name = UPPER(LEFT([Name], 1)) +LOWER(SUBSTRING([Name], 2, LEN([Name]) - 1)), Age += 1
                                    WHERE Id = @minionId";

                for (int i = 0; i < minionIds.Length; i++)
                {
                    var updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@minionId", minionIds[i]);
                    updateCommand.ExecuteNonQuery();
                }

                string selectMinionsQuery = @"SELECT [Name], Age FROM Minions";
                var selectMinionsCommand = new SqlCommand(selectMinionsQuery, connection);
                var reader = selectMinionsCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
                reader.Close();
            }
        }
    }
}
