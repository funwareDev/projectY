using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public event Action Dead;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float amount) 
    {
        if (amount < 0)
            throw new IndexOutOfRangeException("Heal value is incorrect");

        if (_currentHealth + amount > _maxHealth)
        {
            _currentHealth = _maxHealth;
            return;
        }

        _currentHealth += amount;
    }

    public void TakeDamage(float amount)
    {
        if (amount < 0)
            throw new IndexOutOfRangeException("Attack value is incorrect");

        if (_currentHealth - amount <= 0)
        {
            _currentHealth = 0;
            Dead?.Invoke();
        }

        _currentHealth -= amount;
    }

    public void IncreaseMaxHealth(float amount) 
    {
        if (amount < 0)
            throw new IndexOutOfRangeException("Increase value is incorrect");

        _maxHealth += amount;
    }

    public void DecreaseMaxHealth(float amount)
    {
        if (amount < 0)
            throw new IndexOutOfRangeException("Increase value is incorrect");

        _maxHealth += amount;
    }
}
