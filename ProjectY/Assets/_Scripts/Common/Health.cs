using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;


    public void Heal(float amount) 
    {
        if (amount < 0)
            throw new IndexOutOfRangeException("Heal value is incorrect");

        _currentHealth += amount;
    }

    public void TakeDamage(float amount)
    {
        if (amount < 0)
            throw new IndexOutOfRangeException("Attack value is incorrect");

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
