using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public player player;
    public GameObject DarkProj;
    public GameObject LightProj;
    public float speedDark;
    public float speedLight;
    private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        setDirection();

        if (Input.GetKeyDown("e"))
        {
            if (player.isDarkness)
            {
                GameObject projo = Instantiate(DarkProj, transform.position, Quaternion.identity) as GameObject;
                if (player.isFacingRight)
                {
                    projo.GetComponent<SpriteRenderer>().flipX = true;
                }
                projo.GetComponent<Rigidbody2D>().velocity = (direction * speedDark);
                Destroy(projo, 0.75f);
            }
            else
            {
                GameObject projo = Instantiate(LightProj, transform.position, Quaternion.identity) as GameObject;
                if (player.isFacingRight)
                {
                    projo.GetComponent<SpriteRenderer>().flipX = true;
                }
                projo.GetComponent<Rigidbody2D>().velocity = (direction * speedLight);
                Destroy(projo, 0.75f);
            }
        }
    }

    void setDirection()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.3f) 
        {
            if (Input.GetAxisRaw("Vertical") > 0.3f)
            {
                direction = new Vector2(1, 1);
                return;
            }
            if (Input.GetAxisRaw("Vertical") < -0.3f)
            {
                direction = new Vector2(1, -1);
                return;
            }
            direction = new Vector2(1, 0);
            return;
        }
        if (Input.GetAxisRaw("Horizontal") < -0.3f)
        {
            if (Input.GetAxisRaw("Vertical") > 0.3f)
            {
                direction = new Vector2(-1, 1);
                return;
            }
            if (Input.GetAxisRaw("Vertical") < -0.3f)
            {
                direction = new Vector2(-1, -1);
                return;
            }
            direction = new Vector2(-1, 0);
            return;
        }
        if (player.isFacingRight)
        {
            direction = new Vector2(1, 0);
            return;
        }
        else
        {
            direction = new Vector2(-1, 0);
            return;
        }

    }
}
