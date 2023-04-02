using System;
using ECSShooter.Services.ObjectSpawner;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ECSShooter.Logic.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        private Transform _heroTransform;
        
        private const float MinimalDistance = 1;

        [Inject] private UnitSpawner _unitSpawner;

        private void OnEnable()
        {
            if (_unitSpawner.Player != null)
                _heroTransform = _unitSpawner.Player.transform;
            else
                _unitSpawner.PlayerCreated += OnPlayerCreated;
        }

        private void OnPlayerCreated(GameObject obj)
        {
            _heroTransform = _unitSpawner.Player.transform;
        }

        private void Update()
        {
            if (_heroTransform != null && !ReachedDestination)
                _agent.destination = _heroTransform.position;
        }

        private bool ReachedDestination =>
            Vector3.Distance(_agent.transform.position, _heroTransform.position) < MinimalDistance;
    }
}