using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxSlime : MonoBehaviour
{
    public slime slime;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "darkprojo")
        {
            slime.health.Damage(3);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "lightprojo")
        {
            slime.health.Damage(1);
            Destroy(collision.gameObject);
        }
    }
}
