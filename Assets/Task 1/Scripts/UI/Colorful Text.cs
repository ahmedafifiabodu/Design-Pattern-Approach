using System.Collections;
using TMPro;
using UnityEngine;

public class ColorfulText : MonoBehaviour
{
    private TextMeshProUGUI _healthText;
    private Coroutine _colorChangeCoroutine;

    private void Awake() => _healthText = GetComponent<TextMeshProUGUI>();

    private void OnEnable() => _colorChangeCoroutine = StartCoroutine(ColorChangeLoop());

    private void OnDisable()
    {
        if (_colorChangeCoroutine != null)
            StopCoroutine(_colorChangeCoroutine);
    }

    /*    private IEnumerator ColorChangeLoop()
        {
            while (true)
            {
                // Change the color over time
                for (float t = 0; t < 1; t += Time.deltaTime)
                {
                    _healthText.color = Color.Lerp(Color.red, Color.blue, t);
                    yield return null;
                }

                for (float t = 0; t < 1; t += Time.deltaTime)
                {
                    _healthText.color = Color.Lerp(Color.blue, Color.green, t);
                    yield return null;
                }

                for (float t = 0; t < 1; t += Time.deltaTime)
                {
                    _healthText.color = Color.Lerp(Color.green, Color.red, t);
                    yield return null;
                }
            }
        }*/

    /*    private IEnumerator ColorChangeLoop()
        {
            while (true)
            {
                for (float t = 0; t < 1; t += Time.deltaTime / 5)
                {
                    _healthText.color = Color.HSVToRGB(t, 1, 1);
                    yield return null;
                }
            }
        }*/

    private IEnumerator ColorChangeLoop()
    {
        Gradient gradient = new();
        gradient.SetKeys(
            new GradientColorKey[] { new(Color.red, 0.0f), new(Color.blue, 0.5f), new(Color.green, 1.0f) },
            new GradientAlphaKey[] { new(1, 0.0f), new(1, 0.5f), new(1, 1.0f) }
        );

        while (true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / 5)
            {
                _healthText.color = gradient.Evaluate(t);
                yield return null;
            }
        }
    }
}