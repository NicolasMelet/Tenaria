using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batbehavior : MonoBehaviour
{
    public int life = 5;
    public Health health;
    //public float speed = 7f;

    public Transform startPoint;
    public Transform endPoint;
    public float duration = 1.0f;
    public float createdat;
    public float amplitude;
    public int waviness;


    private Vector3 direction;
   
    private void Start()
    {
        createdat = Time.realtimeSinceStartup;  
        transform.position = startPoint.position;
        health.SetLife(life);
        amplitude = Random.value * 3 + 5;
        waviness = Mathf.FloorToInt(Random.value * 5);
       // dest = castle.GetComponent<Transform>();
    }
    
    private void Update()
    {
      float time = Time.realtimeSinceStartup - createdat;
      float tmpnormalize = Mathf.Clamp(time, 0, duration) / duration;
      Vector3 currentposition = (1 - tmpnormalize) * startPoint.position + tmpnormalize * endPoint.position;
      currentposition += Vector3.up * Mathf.Sin(tmpnormalize * waviness * Mathf.PI) * amplitude;
      transform.position = currentposition;

      if (tmpnormalize == 1)
      {
        Destroy(gameObject);
      }

    }
    
     
}

