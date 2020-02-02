using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveInput;
    private bool facingRight = true;
    public Transform groundCheck;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Transform WrenchPos;
    private bool isCarAbove;
    public float CarcheckRadius;
    public LayerMask whatIsCar;

    public Text score;
    private int scoreC = 0;
    private Rigidbody2D rb;
    public float speed;
    public bool checkAllow;
    public Animator animator;
    private int extraJumps;
    public int extraJumpsValue;
    public float jumpForce;
    public GameObject BackGround;
    public bool wrenchProcessing;
    public bool hammerProcessing;
    public GameObject Hydraulic;
    GameObject tempHydraulic;
    public int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 3;
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    

    void Update()
    {
        Jump();
        Wrench();
        Hammer();
        HydraulicSpawn();

        if (health <= 0)
        {
            //Game Over Screen
        }
    }

    void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis(("Horizontal"));

        if (moveInput > 0 )
        {
            BackGround.GetComponent<Parallax>().Move(-0.1f);
        }
        else if (moveInput < 0 )
        {
            BackGround.GetComponent<Parallax>().Move(0.1f);
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == true && moveInput > 0)
            Flip();
        else if (facingRight == false && moveInput < 0)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Jump()
    {
        animator.SetFloat("speed", Mathf.Abs(moveInput));
        if (isGrounded == true && checkAllow)
        {

            animator.SetBool("isJumping", false);

        }

        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            
            animator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            checkAllow = false;
            StartCoroutine(WaitforCheckAllow(0.2f));
        }
        
    }

    IEnumerator WaitforCheckAllow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        checkAllow = true;
    }

    void Wrench()
    {
        if (!hammerProcessing)
        {
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.X) && Mathf.Abs(moveInput) == 0)
            {
                animator.SetBool("Wrench", true);
                wrenchProcessing = true;
                isCarAbove = Physics2D.OverlapCircle(WrenchPos.position, CarcheckRadius, whatIsCar);
                if (isCarAbove)
                {

                    if (tempHydraulic != null)
                    {
                        if (tempHydraulic.GetComponent<HydraulicController>().Car.GetComponent<CarController>().repairTime > 150)
                        {
                            if (tempHydraulic != null)
                            {
                                scoreC++;
                                score.text = scoreC.ToString();;
                                Destroy(tempHydraulic);
                                tempHydraulic = null;
                            }

                        }
                        else
                        {
                            tempHydraulic.GetComponent<HydraulicController>().Car.GetComponent<CarController>().repairTime++;
                        }
                    }

                    
                    Debug.Log("araba");


                }

            }
            else if (Input.GetKeyUp(KeyCode.X) || Mathf.Abs(moveInput) > 0 || Input.GetKeyUp(KeyCode.UpArrow))
            {
                animator.SetBool("Wrench", false);
                wrenchProcessing = false;
            }
        }

        

    }

    void Hammer()
    {
        if (!wrenchProcessing)
        {
            if (Input.GetKey(KeyCode.X) && Mathf.Abs(moveInput) == 0)
            {
                animator.SetBool("Hammer", true);
                hammerProcessing = true;
            }
            else if (Input.GetKeyUp(KeyCode.X) || Mathf.Abs(moveInput) > 0)
            {
                animator.SetBool("Hammer", false);
                hammerProcessing = false;
            }


        }

        

    }

    void HydraulicSpawn()

    {
        if (Input.GetKeyDown(KeyCode.C) && tempHydraulic == null)
        {
            
            tempHydraulic = Instantiate(Hydraulic, new Vector3(transform.position.x, transform.position.y + 1f, -1.5f), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.C) && tempHydraulic != null)
        {
            if (tempHydraulic.GetComponent<HydraulicController>().isCarAbove)
            {
                Debug.Log("üstünde player");
                
                tempHydraulic.GetComponent<Animator>().SetBool("triggered", true);
                tempHydraulic.GetComponent<HydraulicController>().triggered = true;
                tempHydraulic.GetComponent<HydraulicController>().Car.GetComponent<CarController>().catched = true;
                tempHydraulic.GetComponent<HydraulicController>().Car.GetComponent<Animator>().SetBool("catch",true);
                
            }

            
        }


    }

    public void GetDamage()
    {
        health--;
        StartCoroutine(GetDamageFlash());
        
    }
    IEnumerator GetDamageFlash()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        

    }


}
