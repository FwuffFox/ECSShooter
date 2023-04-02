using System;
using JetBrains.Annotations;
using UnityEngine;

namespace ECSShooter.Logic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _cameraDistance;

        [SerializeField] [Range(0f, 1f)]
        private float _lerpValue;
    
        [SerializeField]
        private float _lerpSpeed;
    
        [SerializeField] [CanBeNull] private GameObject _target;

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            if (!_target)
                return;
        
            transform.position = Vector3.Lerp(transform.position, _target.transform.position + _cameraDistance,
             _lerpValue * Time.deltaTime * _lerpSpeed);
        }

        private void OnValidate()
        {
            if (!_target)
                return;
            transform.position = _target.transform.position + _cameraDistance;
        }
    }
}