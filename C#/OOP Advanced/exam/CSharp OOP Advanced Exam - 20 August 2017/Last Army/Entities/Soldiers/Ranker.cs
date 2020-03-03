﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ranker : Soldier
{
    private const double OverallSkillMultiplier = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>()
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(Helmet)
    };

    public Ranker(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallSkillMultiplier;
}
