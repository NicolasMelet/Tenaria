using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public int life = 5;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        health.SetLife(life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
