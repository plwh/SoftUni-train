namespace P02_KingsGambit.Contracts
{
    public interface ISubordinate : INameable, IMortal
    {
        string Action { get; }

        void ReactToAttack();
    }
}