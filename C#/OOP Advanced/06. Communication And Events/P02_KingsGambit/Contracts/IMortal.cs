namespace P02_KingsGambit.Contracts
{
    public interface IMortal
    {
        bool IsAlive { get; }

        void Die();
    }
}
