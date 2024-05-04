using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image damage;
    [SerializeField] private TextMeshProUGUI healthText;

    private PlayerEvent _playerEvent;

    private void Start()
    {
        _playerEvent = ServiceLocator.Instance.GetService<PlayerEvent>();
        _playerEvent.OnHealthChanged += UpdateHealthUI;

        Color color = damage.color;
        color.a = 0;
        damage.color = color;
    }

    //Did not work due to function execution order
    //private void OnEnable() => _playerEvent.OnHealthChanged += UpdateHealthUI;

    private void OnDisable() => _playerEvent.OnHealthChanged -= UpdateHealthUI;

    private void UpdateHealthUI(int health)
    {
        healthText.text = $"Health: {health}";

        Color color = damage.color;
        color.a = 1f;
        damage.color = color;

        StartCoroutine(FadeOutDamageOverlay());
    }

    private IEnumerator FadeOutDamageOverlay()
    {
        Color color = damage.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime;
            damage.color = color;
            yield return null;
        }
    }
}