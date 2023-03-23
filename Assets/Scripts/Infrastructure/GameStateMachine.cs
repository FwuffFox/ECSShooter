using System;
using System.Collections;
using System.Collections.Generic;
using ECSShooter.Factories;
using ECSShooter.Services.CoroutineRunner;
using UnityEngine;

namespace ECSShooter.Infrastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IStateBase> _states;
        private IStateBase _activeState;
        private Coroutine _runningUpdateCoroutine;
        
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly StateFactory _stateFactory;

        public GameStateMachine(ICoroutineRunner coroutineRunner, StateFactory stateFactory)
        {
            _coroutineRunner = coroutineRunner;
            _stateFactory = stateFactory;
        }

        public void CreateStates() => _states = _stateFactory.CreateStates();

        public void Enter<TState>() where TState : class, IEnterState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadEnterState<TPayload>
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