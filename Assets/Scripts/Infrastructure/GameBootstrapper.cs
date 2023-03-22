using System;
using UnityEngine;

namespace ECSShooter.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private static bool _created;

        private void Awake()
        {
            if (_created) return;
            _created = true;
            
            _game = new Game(this);
            _game.GameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            _game?.GameStateMachine?.Run();
        }
    }
}