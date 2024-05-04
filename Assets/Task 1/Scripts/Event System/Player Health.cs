using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private Transform respawnPoint;

    private int _maxHealth;
    private ServiceLocator _serviceLocator;
    private CharacterController _characterController;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.RegisterService(this);

        _maxHealth = health;

        _characterController = GetComponent<CharacterController>();
    }

    internal void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            RespondPlayer();
            ResetHealth();
        }

        _serviceLocator.GetService<PlayerEvent>().InvokeHealthEvent(health);
    }

    private void RespondPlayer()
    {
        _characterController.enabled = false;
        transform.position = respawnPoint.position;
        _characterController.enabled = true;
    }

    private void ResetHealth() => health = _maxHealth;
}