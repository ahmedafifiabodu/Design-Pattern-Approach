using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(EnemyStateManager))]
public class FireballPooling : MonoBehaviour
{
    [SerializeField] private int defultPoolSize = 10;
    [SerializeField] private int maxPoolSize = 10;
    [SerializeField] private Transform bulletPoolParent;
    [SerializeField] internal Transform shootPoint;
    [SerializeField] private EnemyStateManager enemyStateManager;

    private EnemyManager enemyManager;

    private void Awake() => enemyManager = ServiceLocator.Instance.GetService<EnemyManager>();

    internal ObjectPool<Fireball> FirePool { get; private set; }

    private void Start() => FirePool = new ObjectPool<Fireball>(CreateFireball, OnTakeBulletFromPool, ReturnBulletToPool, OnDestroyFireball, true, defultPoolSize, maxPoolSize);

    private Fireball CreateFireball()
    {
        Fireball fireball = Instantiate(enemyStateManager.Enemy.bulletPrefab, shootPoint.position, Quaternion.identity, bulletPoolParent);
        fireball.SetPool(FirePool);
        return fireball;
    }

    private void OnTakeBulletFromPool(Fireball fireball)
    {
        fireball.transform.position = shootPoint.position;
        fireball.transform.right = shootPoint.right;

        fireball.gameObject.SetActive(true);

        Vector3 direction = (enemyManager.playerTransformtion.position - shootPoint.position).normalized;
        fireball.re.velocity = direction * enemyStateManager.Enemy.bulletSpeed;
    }

    private void ReturnBulletToPool(Fireball fireball) => fireball.gameObject.SetActive(false);

    private void OnDestroyFireball(Fireball fireball) => Destroy(fireball.gameObject);

    //Search on "firePool.Dispose();"
}