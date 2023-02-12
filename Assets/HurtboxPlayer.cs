using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxPlayer : MonoBehaviour
{
    public player player;
    private bool canBeDamaged = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ennemy" && canBeDamaged)
        {
            player.health.Damage(1);
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
