using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    GameObject Player;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxMoveCheck();
    }

    public void Move(float movespeed)
    {
        if (movespeed < 0)
        {
            offset -= 0.01f;
        }
        else if (movespeed > 0 )
        {
            offset += 0.01f;
        }

        

    }

    void ParallaxMoveCheck()
    {
        if (Player.transform.position.x > -2.5f && Player.transform.position.x < 18.5f)
        {
            transform.position = new Vector3(Player.transform.position.x + offset, transform.position.y, transform.position.z);

        }
    }
}
