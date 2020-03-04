using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == "" || value == null || value == " ")
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public List<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public int Rating
        {
            get
            {
                if (this.Players.Count == 0)
                    return 0;

                return this.Players.Select(p => p.SkillLevel).Sum() / this.Players.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player target = this.Players.Find(p => p.Name == name);

            if (target == null)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            this.Players.Remove(target);
        }
    }
}
