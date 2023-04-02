using System;
using System.Collections.Generic;
using ECSShooter.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace ECSShooter.Services.ObjectSpawner
{
    public class UnitSpawner
    {
        [Inject] private PrefabFactory _prefabFactory;

        public List<IProgressWriter> ProgressWriters { get; } = new ();
        public List<IProgressReader> ProgressReaders { get; } = new ();

        public event Action<GameObject> PlayerCreated; 
        public GameObject Player { get; private set; }

        public GameObject SpawnPlayer()
        {
            Player = _prefabFactory.CreatePlayer(Vector3.up);
            RegisterProgressWatchers();
            PlayerCreated?.Invoke(Player);
            return Player;
        }

        private void RegisterProgressWatchers()
        {
            foreach (IProgressWriter saveProgress in Player.GetComponentsInChildren<IProgressWriter>())
            {
                ProgressWriters.Add(saveProgress);
            }
            foreach (IProgressReader loadProgress in Player.GetComponentsInChildren<IProgressReader>())
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