using ECSShooter.Data;
using ECSShooter.Services.ObjectSpawner;
using UnityEngine;
using Zenject;

namespace ECSShooter.Services.PersistentProgress
{
    public class PersistentProgress
    {
        public PlayerProgress Progress { get; set; }

        [Inject] private UnitSpawner _unitSpawner;

        public void SaveProgress()
        {
            foreach (IProgressWriter saveProgress in _unitSpawner.ProgressWriters)
            {
                saveProgress.SaveProgress(Progress);
            }
            
            PlayerPrefs.SetString("Progress", JsonUtility.ToJson(Progress));
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString("Progress").DeserializeFromJson<PlayerProgress>();
    }
}