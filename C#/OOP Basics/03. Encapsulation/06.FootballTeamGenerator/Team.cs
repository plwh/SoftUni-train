using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Team
{
    private List<Player> players;
    private string name;

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }

    public int Rating
    {
        get
        {
           if(this.Players.Count == 0) return 0;

           return (int)Math.Round(this.Players.Select(p => p.SkillLevel).Sum() / (double)this.Players.Count);
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == "" || value == null || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player playerToRemove = this.Players.Where(a => a.Name == playerName).FirstOrDefault();
        if (playerToRemove == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        else
        {
            this.Players.Remove(playerToRemove);
        }
    }
}
