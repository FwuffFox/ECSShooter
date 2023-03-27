using ECSShooter.Data;

namespace ECSShooter.Services.PersistentProgress
{
    public interface ISaveProgress
    {
        void SaveProgress(PlayerProgress progress);
    }
}