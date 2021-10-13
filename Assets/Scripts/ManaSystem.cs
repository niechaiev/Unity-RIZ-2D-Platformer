using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem
{
    private int mana = 0;
    public event EventHandler OnManaChanged;

    public ManaSystem(int mana)
    {
        this.mana = mana;

    }

    public int GetMana()
    {
        return mana;
    }

    public void Reduce(int reduceAmount)
    {
        mana -= reduceAmount;
        OnManaChanged(this, EventArgs.Empty);

    }
    public void Add(int addAmount)
    {
        mana += addAmount;
        OnManaChanged(this, EventArgs.Empty);
    }


}
