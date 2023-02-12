using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projoHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            Destroy(gameObject);
        }

        /*if (collision.tag == "enemy")
        {
            if (gameObject.tag == "light")
            {
                collision.gameObject.GetComponent<Health>().Damage(1);
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Health>().Damage(3);
                Destroy(gameObject);
            }
        }*/
    }
}

