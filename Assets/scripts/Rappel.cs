using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rappel : MonoBehaviour
{
    public Transform destination;
    public float teleportDelay = 3f;
    private float timer;
    private bool canTeleport = false;
    public Slider chargeBar;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            canTeleport = true;
            timer = teleportDelay;
        }

        if (Input.GetKeyUp("r"))
        {
            canTeleport = false;
        }

        if (canTeleport)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Teleport();
                canTeleport = false;
            }
        }
        else 
        {
            //chargeBar.value = 0;
        }
    }
    void Teleport()
    {
         transform.position = destination.position;   
    }
    
}
