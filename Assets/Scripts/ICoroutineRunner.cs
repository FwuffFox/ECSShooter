using System.Collections;
using UnityEngine;

namespace ECSShooter
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}