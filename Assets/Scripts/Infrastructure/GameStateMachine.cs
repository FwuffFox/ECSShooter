using System;
using System.Collections.Generic;
using ECSShooter.Services;

namespace ECSShooter.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader)
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