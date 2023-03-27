using UnityEngine;
using Zenject;

namespace ECSShooter.Services.ObjectSpawner
{
    public class UnitSpawner
    {
        [Inject] private PrefabFactory _prefabFactory;
        public GameObject Player { get; private set; }

        public GameObject SpawnPlayer()
        {
            return Player = _prefabFactory.CreatePlayer(Vector3.up);
        }
    }
}