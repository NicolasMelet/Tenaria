using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    public int phase = 1;
    public int enemysLeft = 3;
    public bool win = false;
    
    // Update is called once per frame
    void Update()
    {
        if (enemysLeft <= 0)
        {
            phase += 1;
        }

        if (phase == 6)
        {
            win = true;
        }
    }
}
