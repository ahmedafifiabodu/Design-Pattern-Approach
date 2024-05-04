using System;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    public event Action<int> OnHealthChanged;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    public void InvokeHealthEvent(int _health) => OnHealthChanged?.Invoke(_health);
}