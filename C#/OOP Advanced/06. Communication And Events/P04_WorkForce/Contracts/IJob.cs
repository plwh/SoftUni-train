namespace P04_WorkForce.Contracts
{
    public delegate void UpdateEventHandler(IJob job);

    public interface IJob : INameable
    {
        event UpdateEventHandler UpdateEvent;

        int HoursOfWorkRequired { get; }

        void Update();
    }
}
