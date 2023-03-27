using ECSShooter.Data;

namespace ECSShooter.Services.PersistentProgress
{
    public interface IProgressWriter
    {
        void SaveProgress(PlayerProgress progress);
    }
}