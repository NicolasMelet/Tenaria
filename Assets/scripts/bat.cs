using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public int life = 5;
    public Health health;
    public float speed = 7f;
    public GameObject castle;
    private Transform dest;
    // Start is called before the first frame update
    private void Start()
    {
        health.SetLife(life);
       // dest = castle.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
