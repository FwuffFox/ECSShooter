using ECSShooter.Data;
using ECSShooter.Services.PersistentProgress;
using Zenject;

namespace ECSShooter.Infrastructure.States
{
    public class LoadProgressState : IEnterState, IExitState
    {
        [Inject] private PersistentProgress _progress;
        [Inject] private GameStateMachine _gameStateMachine;
        
        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progress.Progress.WorldData.PositionOnLevel.Level);
        }

        private void LoadProgressOrInitNew()
        {
            _progress.Progress = _progress.LoadProgress() ?? NewProgress();
        }

        private static PlayerProgress NewProgress() => new("Main");

        public void Exit()
        {
            
        }
    }
}