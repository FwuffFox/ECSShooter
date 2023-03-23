namespace ECSShooter.Infrastructure
{
    public interface IStateBase
    {
        
    }

    public interface IExitState : IStateBase
    {
        void Exit();
    }
    
    public interface IEnterState : IStateBase
    {
        void Enter();
    }

    public interface IPayloadedEnterState<in TPayload> : IStateBase
    {
        void Enter(TPayload payload);
    }

    public interface IUpdatableState : IStateBase
    {
        void Update();
    }
}