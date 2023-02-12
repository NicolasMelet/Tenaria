using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int life = 5;
    private int lifeMax = 5;

    public void SetLife(int newLife)
    {
        lifeMax = newLife;
        life = lifeMax;
    }
    public int GetHealth()
    {
        return life;
    }
    public void Damage(int dmg)
    {
        life -= dmg;
        if (life < 0)
        {
            life = 0;
        }
    }
}
