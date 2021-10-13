using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthSystem healthSystem;
    public UI UI;
    public ManaSystem manaSystem;
    private Scene activeScene;
    public float Timer = 0.5f;
    public float Timer2 = 0.5f;
    public int MaxMana;
    public CardsOut cardsOut;
    public StaminaSystem staminaSystem;

    void Start()
    {
        healthSystem = new HealthSystem(100);
        manaSystem = new ManaSystem(0);
        staminaSystem = new StaminaSystem(500);
        UI.Setup(healthSystem, manaSystem, staminaSystem);
        healthSystem.Damage(0);
        activeScene = SceneManager.GetActiveScene();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (healthSystem.GetHealth() <= 0)
        {
           
            SceneManager.LoadScene(3);
        }

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            if (manaSystem.GetMana() < MaxMana)
            {
                manaSystem.Add(1);
            }
            Timer = 0.2f;
        }

        Timer2 -= Time.deltaTime;
        if (Timer2 <= 0f)
        {
            if (staminaSystem.GetStamina() < 100)
            {
                staminaSystem.Add(1);
                if (staminaSystem.GetStamina() == 100)
                {
                    if (cardsOut.DrawCard())
                        staminaSystem.Reduce(100);
                }
            }
            else if (staminaSystem.GetStamina() >= 100)
            {
                if (cardsOut.DrawCard())
                    staminaSystem.Reduce(100);
            }
            Timer2 = 0.04f;
        }

    }
}
