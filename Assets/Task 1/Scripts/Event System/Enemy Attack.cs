using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private bool _canDamage = true;

    private void Awake() => _playerHealth = ServiceLocator.Instance.GetService<PlayerHealth>();

    private void OnTriggerEnter(Collider other)
    {
        if (_canDamage && other.gameObject.CompareTag(GameConstant.PlayerTag))
        {
            _playerHealth.TakeDamage(10);
            _canDamage = false;

            if (gameObject.activeInHierarchy)
                StartCoroutine(ResetDamage());
        }
    }

    private IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(1f);
        _canDamage = true;
    }
}