using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Fireball : MonoBehaviour
{
    [SerializeField] internal Rigidbody re;
    private ObjectPool<Fireball> m_Pool;

    private PlayerHealth _playerHealth;

    private void Awake() => _playerHealth = ServiceLocator.Instance.GetService<PlayerHealth>();


    //where should I set the timer?
    private void OnEnable() => StartCoroutine(DisableFireballAfterTime(5f));

    public void SetPool(ObjectPool<Fireball> pool) => m_Pool = pool;

    private IEnumerator DisableFireballAfterTime(float time)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m_Pool.Release(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameConstant.PlayerTag))
        {
            _playerHealth.TakeDamage(10);
            m_Pool.Release(this);
        }
    }
}