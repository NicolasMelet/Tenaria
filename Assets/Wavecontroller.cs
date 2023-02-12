using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public int nbrbat = 0;
    public int nbrslime = 0;
    
    public Wave(int bat, int slime) {
        nbrbat = bat;
        nbrslime = slime;
    }
    
}

public class Wavecontroller : MonoBehaviour
{
    public GameObject batprefab;
    public float createdat;
    public Wave[] waves;
    public int wavecount = 0;
    public Transform batstartPoint;
    public Transform batendPoint;
    public int childcountatstart;

    // Start is called before the first frame update
    void Start()
    {
        createdat = Time.realtimeSinceStartup;
        childcountatstart = transform.childCount;
        waves = new Wave[] {
            new Wave(4, 6),
            new Wave(2, 4),
            new Wave(3, 7),
        }; 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == childcountatstart)
        {
            summonwave(waves[wavecount]);
            wavecount = (wavecount + 1) % waves.Length;
        }
    }

    void summonwave(Wave wave)
    {
        for (int i = 0; i < wave.nbrbat; i++) {
            GameObject batobject = Instantiate(batprefab, transform);
            Batbehavior bat = batobject.GetComponent<Batbehavior>();
            bat.startPoint = batstartPoint;
            bat.endPoint = batendPoint;
            bat.duration = Random.value * 3 + 7 ;
        }
        
    }
}