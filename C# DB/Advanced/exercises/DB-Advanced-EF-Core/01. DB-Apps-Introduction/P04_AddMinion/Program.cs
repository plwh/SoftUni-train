using System;
using System.Data.SqlClient;

namespace P04_AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\v12.0;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            string[] minionTokens = Console.ReadLine().Split();

            string minionName = minionTokens[1];
            int minionAge = int.Parse(minionTokens[2]);
            string townName = minionTokens[3];

            string villainName = Console.ReadLine().Split()[1];

            connection.Open(); 
            using (connection)
            {
                // check town existence
                string townQuery = "SELECT Id FROM Towns WHERE [Name] = @townName";
                var townCommand = new SqlCommand(townQuery, connection);
                townCommand.Parameters.AddWithValue("@townName", townName);
                var reader = townCommand.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();
                    string addTownQuery = "INSERT INTO Towns VALUES (@townName, 1)";
                    var addTownCommand = new SqlCommand(addTownQuery, connection);
                    addTownCommand.Parameters.AddWithValue("@townName", townName);
                    addTownCommand.ExecuteNonQuery();
                    Console.WriteLine($"Town {townName} was added to the database.");
                }
                reader.Close();

                // get townId
                int minionTownId = 0;
                reader = townCommand.ExecuteReader();
                if (reader.Read())
                {
                    minionTownId = int.Parse(reader[0].ToString());
                }
                reader.Close();

                // check if minion exists with same name, age and townId
                string checkMinionQuery = @"SELECT Id FROM Minions 
                                                WHERE [Name] = @minionName AND Age = @minionAge AND TownId = @minionTownId";
                var checkMinionCommand = new SqlCommand(checkMinionQuery, connection);
                checkMinionCommand.Parameters.AddWithValue("@minionName", minionName);
                checkMinionCommand.Parameters.AddWithValue("@minionAge", minionAge);
                checkMinionCommand.Parameters.AddWithValue("@minionTownId", minionTownId);
                reader = checkMinionCommand.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();

                    // check villain existence
                    string villainQuery = "SELECT Id FROM Villains WHERE [Name] = @villainName";
                    var villainCommand = new SqlCommand(villainQuery, connection);
                    villainCommand.Parameters.AddWithValue("@villainName", villainName);
                    reader = villainCommand.ExecuteReader();

                    if (!reader.Read())
                    {
                        reader.Close();
                        string addVillainQuery = "INSERT INTO Villains VALUES (@villainName, 4)";
                        var addVillainCommand = new SqlCommand(addVillainQuery, connection);
                        addVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                        addVillainCommand.ExecuteNonQuery();
                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                    reader.Close();
                
                    // add minion info to minions table
                    string addMinionQuery = "INSERT INTO Minions VALUES (@minionName, @minionAge, @minionTown)";
                    var addMinionCommand = new SqlCommand(addMinionQuery, connection);
                    addMinionCommand.Parameters.AddWithValue("@minionName", minionName);
                    addMinionCommand.Parameters.AddWithValue("@minionAge", minionAge);
                    addMinionCommand.Parameters.AddWithValue("@minionTown", minionTownId);

                    addMinionCommand.ExecuteNonQuery();

                    // get villain id
                    int villainId = 0;
                    reader = villainCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        villainId = int.Parse(reader[0].ToString());
                    }
                    reader.Close();

                    // get minion id
                    int minionId = 0;
                    reader = checkMinionCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        minionId = int.Parse(reader[0].ToString());
                    }
                    reader.Close();

                    // add both ids to MinionsVillains table
                    string addMinionsVillainsQuery = "INSERT INTO MinionsVillains VALUES (@minionId, @villainId)";
                    var addMinionsVillainsCommand = new SqlCommand(addMinionsVillainsQuery, connection);
                    addMinionsVillainsCommand.Parameters.AddWithValue("@minionId", minionId);
                    addMinionsVillainsCommand.Parameters.AddWithValue("@villainId", villainId);
                    addMinionsVillainsCommand.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }
                reader.Close();
            }
        }
    }
}
