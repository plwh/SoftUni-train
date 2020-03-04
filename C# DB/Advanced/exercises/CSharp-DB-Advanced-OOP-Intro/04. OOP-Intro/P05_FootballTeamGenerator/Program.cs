using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(';');

                switch (tokens[0])
                {
                    case "Team":
                        string name = tokens[1];
                        teams.Add(new Team(name));
                        break;
                    case "Add":
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Team team = teams.Find(t => t.Name == teamName);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Remove":
                        teamName = tokens[1];
                        playerName = tokens[2];
                        team = teams.Where(a => a.Name == teamName).First();
                        try
                        {
                            team.RemovePlayer(playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Rating":
                        teamName = tokens[1];
                        team = teams.Where(a => a.Name == teamName).First();

                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                        }
                        break;
                }
            }
        }
    }
}
