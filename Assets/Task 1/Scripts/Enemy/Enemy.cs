using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    private ObjectPool<Enemy> m_Pool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameConstant.PlayerTag))
            m_Pool.Release(this);
    }

    public void SetPool(ObjectPool<Enemy> pool) => m_Pool = pool;
}