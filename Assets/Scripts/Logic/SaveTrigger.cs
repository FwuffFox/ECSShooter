using System;
using ECSShooter.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace ECSShooter.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        [Inject] private PersistentProgress _progress;
        
        private void OnTriggerEnter(Collider other)
        {
            _progress.SaveProgress();
            
            Debug.Log($"Game Saved: {JsonUtility.ToJson(_progress.Progress)}");
        }
    }
}