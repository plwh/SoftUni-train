using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P07_PrintAllMinionNames
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
                try
                {
                    var command = new SqlCommand("SELECT [Name] FROM Minions", connection);
                    var reader = command.ExecuteReader();
                    var names = new List<string>();

                    using (reader)
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                names.Add(Convert.ToString(reader[0]));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        for (int i = 0, j = names.Count - 1; i < names.Count / 2; i++, j--)
                        {
                            Console.WriteLine($"{names[i]}{Environment.NewLine}{names[j]}");
                        }
                        if (names.Count % 2 != 0)
                        {
                            Console.WriteLine(names[names.Count / 2]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
