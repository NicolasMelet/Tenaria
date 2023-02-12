using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public player player;
    public GameObject DarkProj;
    public GameObject LightProj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            if (player.isDarkness)
            {
                GameObject projo = Instantiate(DarkProj, transform.position, Quaternion.identity) as GameObject;
            }
            else
            {
                GameObject projo = Instantiate(LightProj, transform.position, Quaternion.identity) as GameObject;
            }
        }
    }
}
