using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxPlayer : MonoBehaviour
{
    public player player;
    private bool canBeDamaged = true;
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "enemy" && canBeDamaged)
        {
            player.health.TakeDamage(25);
            canBeDamaged = false;
            StartCoroutine(Invincible());
        }
    }

    private IEnumerator Invincible()
    {
        yield return new WaitForSeconds(1);
        canBeDamaged = true;
    }
}
