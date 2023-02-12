using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Health health;

    // Update is called once per frame
    void Update()
    {
        if (health.GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
