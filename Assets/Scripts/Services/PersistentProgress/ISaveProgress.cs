using ECSShooter.Data;

namespace ECSShooter.Services.PersistentProgress
{
    public interface ISaveProgress : ILoadProgress
    {
        void SaveProgress(PlayerProgress progress);
    }
}