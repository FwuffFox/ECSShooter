using UnityEngine;
using Zenject;

namespace ECSShooter.Services
{
    public class PrefabFactory
    {
        [Inject] private readonly DiContainer _diContainer;

        public GameObject CreatePlayer(Vector3 position)
        {
            GameObject player = Object.Instantiate(
                Resources.Load<GameObject>("Prefabs/Player"), position, Quaternion.identity);
            _diContainer.InjectGameObject(player);
            return player;
        }
    }
}