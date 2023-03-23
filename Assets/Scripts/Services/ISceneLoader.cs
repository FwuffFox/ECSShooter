using System;
using System.Collections;

namespace ECSShooter.Services
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null);
        IEnumerator LoadScene(string name, Action onLoaded = null);
    }
}