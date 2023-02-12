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
        createdat = Time.time;  
        transform.position = startPoint.position;
        health.SetLife(life);
        amplitude = Random.value * 3 + 3;
        waviness = Mathf.FloorToInt(Random.value * 6) + 4;
       // dest = castle.GetComponent<Transform>();
    }
    
    private void Update()
    {
      float time = Time.time - createdat;
      float tmpnormalize = Mathf.Clamp(time, 0, duration) / duration;
      Vector3 currentposition = (1 - tmpnormalize) * startPoint.position + tmpnormalize * endPoint.position;
      currentposition += computesinusoffset(tmpnormalize);
      transform.position = currentposition;

      if (tmpnormalize == 1)
      {
        Destroy(gameObject);
      }

    }

    public virtual Vector3 computesinusoffset(float tmpnormalize)
    {
        return Vector3.up * Mathf.Sin(tmpnormalize * waviness * Mathf.PI) * amplitude;
    }
    
     
}

