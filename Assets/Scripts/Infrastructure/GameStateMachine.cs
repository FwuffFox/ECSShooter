using System;
using System.Collections.Generic;

namespace ECSShooter.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this)
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState newState = _states[typeof(TState)];
            _activeState = newState;
            _activeState.Enter();
        }
    }
}