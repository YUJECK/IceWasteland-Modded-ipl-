using System;
using System.Collections.Generic;

public sealed class GameStateMachine
{
    public IExitableState CurrentState { get; private set; }
    private readonly Dictionary<Type, IExitableState> states;

    public GameStateMachine()
    {
        states = new Dictionary<Type, IExitableState>()
        {
            //states
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }
    public void Enter<TState, TArg>(TArg arg) where TState : class, IPayloadedState<TArg>
    {
        IPayloadedState<TArg> state = ChangeState<TState>();
        state.Enter(arg);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        CurrentState?.Exit();
        
        TState state = GetState<TState>();
        CurrentState = state;

        return state;
    }
    private TState GetState<TState>() where TState : class, IExitableState
        => states[typeof(TState)] as TState;
}