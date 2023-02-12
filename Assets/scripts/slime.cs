using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : Batbehavior
{
   public override Vector3 computesinusoffset(float tmpnormalize)
    {
        return Vector3.up * Mathf.Abs(Mathf.Sin(tmpnormalize * waviness * Mathf.PI) * amplitude);
    }
}
