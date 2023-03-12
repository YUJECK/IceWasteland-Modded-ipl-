public interface IPayloadedState<TArg> : IExitableState
{
    void Enter(TArg arg);
}