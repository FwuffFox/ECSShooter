using System.Collections;
using UnityEngine;

namespace ECSShooter.Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}