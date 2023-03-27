using ECSShooter.Data;

namespace ECSShooter.Services.PersistentProgress
{
    public interface ILoadProgress
    {
        void LoadProgress(PlayerProgress progress);
    }
}