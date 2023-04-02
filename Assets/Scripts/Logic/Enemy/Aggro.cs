using System;
using UnityEngine;

namespace ECSShooter.Logic.Enemy
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AgentMoveToPlayer _agentMove;

        private void Start()
        {
            _triggerObserver.TriggerEnter += OnObserverTriggerEnter;
            _triggerObserver.TriggerExit += OnObserverTriggerExit;

            _agentMove.enabled = false;
        }
        
        private void OnObserverTriggerEnter(Collider obj)
        {
            _agentMove.enabled = true;
        }
        
        private void OnObserverTriggerExit(Collider obj)
        {
            _agentMove.enabled = false;
        }
    }
}