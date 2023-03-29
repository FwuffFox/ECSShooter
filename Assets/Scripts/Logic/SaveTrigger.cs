using System;
using ECSShooter.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace ECSShooter.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        [Inject] private PersistentProgress _progress;

        [SerializeField] private SphereCollider _collider;
        
        private void OnTriggerEnter(Collider other)
        {
            _progress.SaveProgress();
            
            Debug.Log($"Game Saved: {JsonUtility.ToJson(_progress.Progress)}");
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0.97f, 0f, 0.57f);
            Gizmos.DrawWireSphere(transform.position + _collider.center, _collider.radius);
        }
    }
}