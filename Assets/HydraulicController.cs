using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraulicController : MonoBehaviour
{

    public Transform CarCheckPos;
    public bool isCarAbove;
    public float CarcheckRadius;
    public LayerMask whatIsCar;
    public GameObject Car;
    public bool triggered;


    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        CarCheck();
        if (isCarAbove)
        {
            
        }
    }

    void CarCheck()
    {
        isCarAbove = Physics2D.OverlapCircle(CarCheckPos.position, CarcheckRadius, whatIsCar);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            Car = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Car" && !triggered)
        {
            Car = null;
        }
    }

    IEnumerator WaitforCheckAllow(float waitTime , Collider2D collision)
    {
        yield return new WaitForSeconds(waitTime);
        
    }
}
