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
    public GameObject slimeprefab;
    public Transform slimestartPoint;
    public Transform slimeendPoint;
    public int childcountatstart;

    // Start is called before the first frame update
    void Start()
    {
        createdat = Time.realtimeSinceStartup;
        childcountatstart = transform.childCount;
        waves = new Wave[] {
            new Wave(2, 1),
            new Wave(3, 1),
            new Wave(3, 2),
            new Wave(3, 3),
            new Wave(4, 3),
            new Wave(4, 5),
            new Wave(4, 4),
            new Wave(5, 5),
            new Wave(5, 6),
            new Wave(5, 5),
            new Wave(6, 6),
            new Wave(5, 8),
            new Wave(7, 7),
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
            bat.duration = Random.value * 6 + 14 ;
        }

        for (int i = 0; i < wave.nbrslime; i++) {
            GameObject slimeobject = Instantiate(slimeprefab, transform);
            slime slime = slimeobject.GetComponent<slime>();
            slime.startPoint = slimestartPoint;
            slime.endPoint = slimeendPoint;
            slime.duration = Random.value * 6 + 12 ;
        }
    }
}