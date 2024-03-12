using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName ="EnemyType", menuName ="Shmup/EnemyType")]
    public class EnemyType : ScriptableObject 
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed = 2f;
    }
}
