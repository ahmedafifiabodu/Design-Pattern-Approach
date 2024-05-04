using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPooling))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField] internal Transform playerTransformtion;
    [SerializeField] private List<Enemies> enemies;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    private void Start()
    {
        foreach (var enemy in enemies)
            enemy.enemyStateManager.enemyIndex = GetIndexByEnemy(enemy);
    }

    internal int EnemiesCount => enemies.Count;

    internal Enemies GetEnemyByIndex(int index)
    {
        if (index < 0 || index >= enemies.Count)
            return null;

        return enemies[index];
    }

    internal int GetIndexByEnemy(Enemies enemy)
    {
        if (enemy == null)
            return -1;

        int _enemyIndex = 0;

        foreach (var _enemies in enemies)
        {
            if (ReferenceEquals(enemy, _enemies))
                return _enemyIndex;

            _enemyIndex++;
        }

        return -1;
    }
}