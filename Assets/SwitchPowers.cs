using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPowers : MonoBehaviour
{
    public player player;
    public Sprite DarkSprite;
    public Sprite LightSprite;
    public RuntimeAnimatorController DarkControll;
    public RuntimeAnimatorController LightControll;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            player.isDarkness = !player.isDarkness;
            //switchPowers(player.isDarkness);
        }
    }

    /*public void switchPowers(bool isDarkness)
    {
        if (isDarkness)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = DarkSprite;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = DarkControll;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = LightSprite;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = LightControll;
        }*/
    //}
}
