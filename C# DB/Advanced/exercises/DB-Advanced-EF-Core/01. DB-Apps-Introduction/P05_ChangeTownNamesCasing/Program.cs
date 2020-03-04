using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05_ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\v12.0;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            string countryName = Console.ReadLine();
            List<string> townNames = new List<string>();

            connection.Open();
            using (connection)
            {
                // check country existence

                string checkCountryQuery = "SELECT Id FROM Countries WHERE [Name] = @countryName";
                var checkCountryCommand = new SqlCommand(checkCountryQuery, connection);
                checkCountryCommand.Parameters.AddWithValue("@countryName", countryName);

                var reader = checkCountryCommand.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    Console.WriteLine("No town names were affected.");
                    return;
                }
                reader.Close();

                // check if there are cities connected

                string getCitiesQuery = @"SELECT t.[Name]
                                          FROM Towns AS t
                                          JOIN Countries AS c ON t.CountryId = c.Id
                                          WHERE c.[Name] = @countryName;";
                var getCitiesCommand = new SqlCommand(getCitiesQuery, connection);
                getCitiesCommand.Parameters.AddWithValue("@countryName", countryName);

                reader = getCitiesCommand.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                townNames.Add(reader[0].ToString());
                while (reader.Read())
                {
                    townNames.Add(reader[0].ToString());
                }
                reader.Close();

                // update city names to uppercase and print result

                string updateCitiesQuery = @"UPDATE Towns
                                                SET Name = UPPER(Name)
                                                WHERE Name = @currTown";

                for (int i = 0; i < townNames.Count; i++)
                {
                    var updateCitiesCommand = new SqlCommand(updateCitiesQuery, connection);
                    updateCitiesCommand.Parameters.AddWithValue("@currTown", townNames[i]);
                    updateCitiesCommand.ExecuteNonQuery();
                }

                Console.WriteLine($"{townNames.Count} names were affected.");
                Console.WriteLine($"[{string.Join(", ", townNames).ToUpper()}]");
            }
        }
    }
}
