using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("barricade"))
        {
            speed = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(2 * Time.deltaTime * speed, 0,0);
        transform.localScale = new Vector2(2, 2);
    }
}
