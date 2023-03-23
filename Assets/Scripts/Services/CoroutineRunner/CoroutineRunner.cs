using System;
using UnityEngine;

namespace ECSShooter.Services.CoroutineRunner
{
    class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void OnEnable()
        {
            DontDestroyOnLoad(this);
        }
    }
}