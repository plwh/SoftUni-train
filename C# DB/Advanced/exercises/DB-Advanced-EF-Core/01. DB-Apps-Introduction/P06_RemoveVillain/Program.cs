using System;
using System.Data.SqlClient;

namespace P06_RemoveVillain
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
                try
                {
                    string nameQuery = "SELECT [Name] from Villains WHERE Id = @villainId";
                    var nameCommand = new SqlCommand(nameQuery, connection);
                    nameCommand.Parameters.AddWithValue("@villainId", villainId);
                    var reader = nameCommand.ExecuteReader();
                    
                    if (!reader.Read())
                    {
                        reader.Close();
                        throw new ArgumentException("No such villain was found.");
                    }
                    string villainName = Convert.ToString(reader[0]);
                    reader.Close();

                    string mvQuery = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                    var mvCommand = new SqlCommand(mvQuery, connection);
                    mvCommand.Parameters.AddWithValue("@villainId", villainId);
                    int minionsReleased = mvCommand.ExecuteNonQuery();

                    string villainQuery = "DELETE FROM Villains WHERE Id = @villainId";
                    var villainCommand = new SqlCommand(villainQuery, connection);
                    villainCommand.Parameters.AddWithValue("@villainId", villainId);
                    villainCommand.ExecuteNonQuery();

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionsReleased} minions were released.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
