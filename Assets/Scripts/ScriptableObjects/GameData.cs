using UnityEngine;

namespace ECSShooter.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ECSShooter/GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        public GameObject playerPrefab;
    }
}