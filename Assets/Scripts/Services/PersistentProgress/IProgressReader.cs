using ECSShooter.Data;

namespace ECSShooter.Services.PersistentProgress
{
    public interface IProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}