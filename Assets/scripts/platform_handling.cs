using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_handling : MonoBehaviour
{

    public GameObject platform;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platform.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        platform.GetComponent<BoxCollider2D>().enabled = true;
    }
}
