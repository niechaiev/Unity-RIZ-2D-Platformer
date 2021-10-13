using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int health;
    public event EventHandler OnHealthChanged;

    public HealthSystem(int health)
    {
        this.health = health;

    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        OnHealthChanged(this, EventArgs.Empty);
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        OnHealthChanged(this, EventArgs.Empty);
    }


}
