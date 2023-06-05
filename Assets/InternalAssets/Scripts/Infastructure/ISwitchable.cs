namespace IceWasteland.Infrastructure
{
    public interface ISwitchable
    {
        bool IsEnabled { get; }

        void Enable();
        void Disable();
    }
}