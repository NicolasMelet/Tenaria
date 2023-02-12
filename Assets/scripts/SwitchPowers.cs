using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPowers : MonoBehaviour
{
    public player player;
    public Sprite DarkSprite;
    public Sprite LightSprite;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            player.isDarkness = !player.isDarkness;
        }
    }
}
