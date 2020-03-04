using System;
using System.Data.SqlClient;

namespace P02_VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\v12.0;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            connection.Open();
            using (connection)
            {
                string villainQuery = @"SELECT [Name], COUNT(*)
                                        FROM Villains AS v
                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                        GROUP BY[Name]
                                        HAVING COUNT(mv.MinionId) > 3
                                        ORDER BY COUNT(mv.MinionId) DESC";

                var villainCommand = new SqlCommand(villainQuery, connection);

                var reader = villainCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]}");
                }
                reader.Close();
            }
        }

        static void ExecuteCommand(string command, SqlConnection connection)
        {
            var sql = new SqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
    }
}
