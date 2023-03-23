using System;
using System.Collections.Generic;
using ECSShooter.Infrastructure;
using Zenject;

namespace ECSShooter.Factories
{
    public class StateFactory
    {
        [Inject] private readonly DiContainer _diContainer;

        public Dictionary<Type, IStateBase> CreateStates() => new()
        {
            [typeof(BootstrapState)] = BindState(new BootstrapState()),
            [typeof(LoadLevelState)] = BindState(new LoadLevelState()),
        };

        private IStateBase BindState<TState>(TState state) where TState : class, IStateBase
        {
            _diContainer.BindInstance(state).AsSingle();
            _diContainer.Inject(state);
            return state;
        }
    }
}