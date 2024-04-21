using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damageValue = 10f;

    private float _currentHealth;

    public float MaxHealth => _maxHealth;

    public Action<float> Changed;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(_damageValue);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        Changed.Invoke(_currentHealth);
    }
}
