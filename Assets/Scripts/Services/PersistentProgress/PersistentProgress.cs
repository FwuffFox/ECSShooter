using ECSShooter.Data;
using UnityEngine;

namespace ECSShooter.Services.PersistentProgress
{
    public class PersistentProgress
    {
        public PlayerProgress Progress { get; set; }

        public void SaveProgress()
        {
            
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString("Progress").DeserializeFromJson<PlayerProgress>();
    }
}