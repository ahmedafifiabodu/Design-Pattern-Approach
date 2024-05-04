using UnityEngine;

[System.Serializable]
public class Enemies
{
    [Header("Settings")]
    [SerializeField] internal Enemy enemyPrefab;

    [SerializeField] internal int enemyCounts;
    [SerializeField] internal Transform[] patrolPoints;
    [SerializeField] internal Transform enemyParent;
    [SerializeField] internal EnemyStateManager enemyStateManager;
    [SerializeField] internal float sightRange = 10f;
    [SerializeField] internal float attackRange = 2f;

    [Header("Pooling Settings")]
    [SerializeField] internal int defultPoolSize = 10;

    [SerializeField] internal int maxPoolSize = 10;

    [SerializeField][HideInInspector] public bool canShoot = false;
    [SerializeField][HideInInspector] internal Fireball bulletPrefab;
    [SerializeField][HideInInspector] internal float bulletSpeed = 10f;
}