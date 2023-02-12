using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxBat : MonoBehaviour
{
    public bat bat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(bat.health.GetHealth());
        if (collision.tag == "darkprojo")
        {
            bat.health.Damage(3);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "lightprojo")
        {
            bat.health.Damage(1);
            Destroy(collision.gameObject);
        }
    }
}
