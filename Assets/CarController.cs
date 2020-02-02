using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool rightDirection;
    public float speed;
    public bool catched;
    public bool repaired;
    public int repairTime;
    bool once;
    public GameObject Projectile;
    Rigidbody2D rb;
    float lastTime;
    float cd;
    // Start is called before the first frame update
    void Start()
    {
        cd = 5f;
        
        rb = GetComponent<Rigidbody2D>();

        if (rightDirection)
        {

        }
        else
        {

            Flip();
        }

        once = false;
        repaired = false;
        repairTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!catched)
        {
            Move();
            Attack();

        }
        else
        {
            if (!once)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5f;
                gameObject.GetComponent<Rigidbody2D>().mass = 9000f;
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(2.1f, 1f);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.25f);
                once = true;
                StartCoroutine(Carry(0.5f));
            }
        }

        if (repairTime>150)
        {
            repaired = true;
        }

        if (repaired)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = -1f;
            gameObject.GetComponent<Rigidbody2D>().mass = 5f;
        }

        
    }

    void Move()
    {
        if (rightDirection)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

        }

    }

    void Flip()
    {
        
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Attack()
    {
        if (Time.time > lastTime + cd)
        {
            if (rightDirection)
            {
                int rnd = Random.Range(1, 3);
                if (rnd == 1)
                {
                    Projectile.GetComponent<projectilecontroller>().projectileRight = true;
                    Instantiate(Projectile, new Vector3 (transform.position.x , transform.position.y - 1f , -2), Quaternion.identity);
                }
                else if (rnd == 2)
                {
                    Projectile.GetComponent<projectilecontroller>().projectileRight = true;
                    Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 2f, -2), Quaternion.identity);
                }
                
            }
            else
            {
                int rnd = Random.Range(1, 3);
                if (rnd == 1)
                {
                    Projectile.GetComponent<projectilecontroller>().projectileRight = false;
                    Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 1f, -2), Quaternion.identity);
                }
                else if (rnd == 2)
                {
                    Projectile.GetComponent<projectilecontroller>().projectileRight = false;
                    Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 2f, -2), Quaternion.identity);
                }
            }

            lastTime = Time.time;

        }
        
    }

    IEnumerator Carry(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        transform.position = new Vector3(transform.position.x, -1.8f, transform.position.z);
        yield return new WaitForSeconds(waitTime);
        transform.position = new Vector3(transform.position.x, -1f, transform.position.z);

    }

}
