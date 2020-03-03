using System;
using System.Collections.Generic;
using System.Text;

class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.Name = name;
        this.NumberOfBadges = 0;
        this.Pokemons = new List<Pokemon>();
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}
