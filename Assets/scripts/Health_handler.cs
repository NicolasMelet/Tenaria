using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_handler : MonoBehaviour
{

     public int maxHealth = 100;
     public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
