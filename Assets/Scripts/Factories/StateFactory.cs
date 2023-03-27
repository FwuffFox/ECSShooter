using System;
using System.Collections.Generic;
using ECSShooter.Infrastructure;
using ECSShooter.Infrastructure.States;
using Zenject;

namespace ECSShooter.Factories
{
    public class StateFactory
    {
        [Inject] private readonly DiContainer _diContainer;

        public Dictionary<Type, IStateBase> CreateStates() => new()
        {
            [typeof(BootstrapState)] = BindState(new BootstrapState()),
            [typeof(LoadProgressState)] = BindState(new LoadProgressState()),
            [typeof(LoadLevelState)] = BindState(new LoadLevelState()),
            [typeof(GameLoopState)] = BindState(new GameLoopState()),
        };

        private IStateBase BindState<TState>(TState state) where TState : class, IStateBase
        {
            _diContainer.BindInstance(state).AsSingle();
            _diContainer.Inject(state);
            return state;
        }
    }
}