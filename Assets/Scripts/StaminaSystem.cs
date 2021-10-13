using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSystem
{
    private int stamina = 0;
    public event EventHandler OnStaminaChanged;

    public StaminaSystem(int stamina)
    {
        this.stamina = stamina;

    }

    public int GetStamina()
    {
        return stamina;
    }

    public void Reduce(int reduceAmount)
    {
        stamina -= reduceAmount;
        OnStaminaChanged(this, EventArgs.Empty);

    }
    public void Add(int addAmount)
    {
        stamina += addAmount;
        OnStaminaChanged(this, EventArgs.Empty);
    }


}
