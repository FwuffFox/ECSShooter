using ECSShooter.Services;

namespace ECSShooter.Infrastructure
{
    public class Game
    {
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            GameStateMachine = new GameStateMachine(
                sceneLoader: new SceneLoader(coroutineRunner),
                coroutineRunner: coroutineRunner);
        }
    }
}