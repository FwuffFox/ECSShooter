using System;
using UnityEngine;

namespace ECSShooter.Logic.Enemy
{
    
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;

        protected void OnTriggerEnter(Collider obj)
        {
            TriggerEnter?.Invoke(obj);
        }

        protected void OnTriggerExit(Collider obj)
        {
            TriggerExit?.Invoke(obj);
        }
    }
}