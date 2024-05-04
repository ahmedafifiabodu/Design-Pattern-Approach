using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPooling : MonoBehaviour
{
    private EnemyManager enemyManager;
    internal List<ObjectPool<Enemy>> EnemyPools { get; private set; }

    private void Start()
    {
        enemyManager = ServiceLocator.Instance.GetService<EnemyManager>();

        EnemyPools = new List<ObjectPool<Enemy>>();
        for (int i = 0; i < enemyManager.EnemiesCount; i++)
        {
            Enemies enemies = enemyManager.GetEnemyByIndex(i);
            ObjectPool<Enemy> pool = new(() => CreateEnemy(enemies), OnTakeBulletFromPool, ReturnBulletToPool, OnDestroyFireball, true, enemies.defultPoolSize, enemies.maxPoolSize);
            EnemyPools.Add(pool);

            for (int j = 0; j < enemies.enemyCounts; j++)
                CreateEnemy(enemies);
        }
    }

    private Enemy CreateEnemy(Enemies enemies)
    {
        Enemy enemy = Instantiate(enemies.enemyPrefab, enemies.enemyPrefab.transform.position, Quaternion.identity, enemies.enemyParent);
        enemy.SetPool(EnemyPools[enemyManager.GetIndexByEnemy(enemies)]);

        if (enemy.TryGetComponent<EnemyStateManager>(out var enemyStateManager))
            enemyStateManager.enemyIndex = enemyManager.GetIndexByEnemy(enemies);

        return enemy;
    }

    private void OnTakeBulletFromPool(Enemy enemy) => enemy.gameObject.SetActive(true);

    private void ReturnBulletToPool(Enemy enemy) => enemy.gameObject.SetActive(false);

    private void OnDestroyFireball(Enemy enemy) => Destroy(enemy.gameObject);

    //Search on "firePool.Dispose();"
}