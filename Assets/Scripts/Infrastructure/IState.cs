namespace ECSShooter.Infrastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}