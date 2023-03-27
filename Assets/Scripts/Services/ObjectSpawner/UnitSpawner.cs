using System.Collections.Generic;
using ECSShooter.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace ECSShooter.Services.ObjectSpawner
{
    public class UnitSpawner
    {
        [Inject] private PrefabFactory _prefabFactory;

        public List<ISaveProgress> ProgressWriters { get; } = new ();
        public List<ILoadProgress> ProgressReaders { get; } = new ();
        public GameObject Player { get; private set; }

        public GameObject SpawnPlayer()
        {
            Player = _prefabFactory.CreatePlayer(Vector3.up);
            RegisterProgressWatchers();
            return Player;
        }

        private void RegisterProgressWatchers()
        {
            foreach (ISaveProgress saveProgress in Player.GetComponentsInChildren<ISaveProgress>())
            {
                ProgressWriters.Add(saveProgress);
            }
            foreach (ILoadProgress loadProgress in Player.GetComponentsInChildren<ILoadProgress>())
            {
                ProgressReaders.Add(loadProgress);
            }
        }

        public void Cleanup()
        {
            ProgressWriters.Clear();
            ProgressReaders.Clear();
        }
    }
}