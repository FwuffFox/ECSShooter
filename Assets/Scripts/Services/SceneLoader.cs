using System;
using System.Collections;
using ECSShooter.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ECSShooter.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded = null)
            => _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        
        public IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(name);

            while (!loadSceneAsync.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}