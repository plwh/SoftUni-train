using System;
using System.Data.SqlClient;

namespace P03_MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\v12.0;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            int villainId = int.Parse(Console.ReadLine());

            connection.Open();
            using (connection)
            {
                string villainQuery = "SELECT v.[Name] FROM Villains AS v WHERE Id = @villainId";
                var villainCommand = new SqlCommand(villainQuery, connection);

                villainCommand.Parameters.AddWithValue("@villainId", villainId);

                var reader = villainCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Villain: {reader[0]}");
                }
                reader.Close();

                string minionsQuery = "SELECT [Name], Age FROM Minions AS m " +
                                      "JOIN MinionsVillains AS mv ON m.Id = mv.MinionId " +
                                      "WHERE mv.VillainId = @villainId";
                var minionsCommand = new SqlCommand(minionsQuery, connection);

                minionsCommand.Parameters.AddWithValue("@villainId", villainId);
                reader = minionsCommand.ExecuteReader();

                int counter = 1;
                while (reader.Read())
                {
                    Console.WriteLine($"{counter} {reader[0]} {reader[1]}");
                    counter++;
                }
            }
        }

        static void ExecuteCommand(string command, SqlConnection connection)
        {
            var sql = new SqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
    }
}
