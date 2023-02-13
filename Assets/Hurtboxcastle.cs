using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtboxcastle : MonoBehaviour
{
    public Health_handler player_health;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "enemy")
            {
                player_health.TakeDamage(25);
                Destroy(collision.gameObject);
            }
        }

}
