using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilecontroller : MonoBehaviour
{
    public bool projectileRight;

    // Start is called before the first frame update
    void Start()
    {
        if (projectileRight)
        {

        }
        else
        {

            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileRight)
        {
            transform.Translate(new Vector2(0.02f, 0));
        }
        else
        {
            transform.Translate(new Vector2(-0.02f, 0));
        }
    }

    void Flip()
    {

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            collision.GetComponent<PlayerController>().GetDamage();
            Destroy(gameObject);

        }
    }
}
