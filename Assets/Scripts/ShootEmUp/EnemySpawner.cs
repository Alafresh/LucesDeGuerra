using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        float spawnTimer;
        int enemiesSpawned;

        private void OnValidate()
        {
            splines = new List<SplineContainer> (GetComponentsInChildren<SplineContainer>());
        }

        void Start() => enemyFactory = new EnemyFactory();

        private void Update()
        {
            spawnTimer += Time.deltaTime;
            if (enemiesSpawned < maxEnemies && spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0;
            }
        }

        public void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];
            // possible optimization - pool enemies
            enemyFactory.CreateEnemy(enemyType, spline);
            enemiesSpawned++;
        }
    }
}
