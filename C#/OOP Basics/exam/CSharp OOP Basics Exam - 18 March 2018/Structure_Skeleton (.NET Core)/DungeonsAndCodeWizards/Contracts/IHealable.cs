﻿namespace DungeonsAndCodeWizards.Contracts
{
    using DungeonsAndCodeWizards.Models;

    public interface IHealable
    {
        void Heal(Character character);
    }
}