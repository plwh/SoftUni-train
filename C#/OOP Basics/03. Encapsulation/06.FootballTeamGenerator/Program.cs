using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string line = "";
            while ((line = Console.ReadLine()) != "END")
            {
                string[] tokens = line.Split(';');
                    
                switch (tokens[0])
                {
                    case "Team":
                        teams.Add(new Team(tokens[1]));
                        break;
                    case "Add":
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Team team;
                        team = teams.Where(a => a.Name == teamName).FirstOrDefault();

                        if (team == null)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                            }
                            catch (Exception ex)
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
                        team = teams.Where(a => a.Name == teamName).FirstOrDefault();

                        if (team == null)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
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
