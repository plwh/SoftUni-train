﻿namespace DungeonsAndCodeWizards.Contracts
{
    using DungeonsAndCodeWizards.Models;

    public interface IAttackable
    {
        void Attack(Character character);
    }
}
