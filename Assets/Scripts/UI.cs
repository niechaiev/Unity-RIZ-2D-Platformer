using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    private HealthSystem healthSystem;
    private ManaSystem manaSystem;
    private StaminaSystem staminaSystem;

    public void Setup(HealthSystem healthSystem, ManaSystem manaSystem, StaminaSystem staminaSystem)
    {
        this.healthSystem = healthSystem;
        this.manaSystem = manaSystem;
        this.staminaSystem = staminaSystem;
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        manaSystem.OnManaChanged += ManaSystem_OnManaChanged;
        staminaSystem.OnStaminaChanged += StaminaSystem_OnStaminaChanged;
    }

    private void StaminaSystem_OnStaminaChanged(object sender, EventArgs e)
    {
        transform.Find("Stamina").GetComponent<Text>().text = "Stamina: " + staminaSystem.GetStamina().ToString() +"%";
    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        transform.Find("HP").GetComponent<Text>().text = "HP: " + healthSystem.GetHealth().ToString();
    }

    private void ManaSystem_OnManaChanged(object sender, EventArgs e)
    {
        transform.Find("Mana").GetComponent<Text>().text = "Mana: " + manaSystem.GetMana().ToString();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Find("HP").GetComponent<Text>().text = healthSystem.GetHealth().ToString();

    }
}
