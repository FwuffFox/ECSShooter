using System;
using System.Collections;
using System.Collections.Generic;
using ECSShooter.Services;
using UnityEngine;

namespace ECSShooter.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IStateBase> _states;
        private IStateBase _activeState;
        private readonly ICoroutineRunner _coroutineRunner;

        private Coroutine _runningUpdateCoroutine;

        public GameStateMachine(SceneLoader sceneLoader, ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _states = new Dictionary<Type, IStateBase>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
            };
        }
        
        public void Enter<TState>() where TState : class, IEnterState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedEnterState<TPayload>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IStateBase
            => _states[typeof(TState)] as TState;
        
        private TState ChangeState<TState>() where TState : class, IStateBase
        {
            if (_activeState is IExitState exitState)
            {
                if (_activeState is IUpdatableState && _runningUpdateCoroutine != null)
                    _coroutineRunner.StopCoroutine(_runningUpdateCoroutine);
                exitState.Exit();
            }
            
            TState newState = GetState<TState>();
            _activeState = newState;

            if (newState is IUpdatableState updatableState)
                _runningUpdateCoroutine = _coroutineRunner
                    .StartCoroutine(RunUpdatableState(updatableState));
            
            return newState;
        }

        private IEnumerator RunUpdatableState(IUpdatableState state)
        {
            while (true)
            {
                state.Update();
                yield return null;
            }
        }
    }
}