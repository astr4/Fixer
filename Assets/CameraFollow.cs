using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    private void FixedUpdate()
    {
        OffSetCal();
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z); 
    }

    void OffSetCal()
    {
        if (target.position.x < -2.5f)
        {
            offset.x = -(target.position.x - (-2.5f));

        }
        else if (target.position.x > 18.5f)
        {
            offset.x = -(target.position.x - 18.5f);
        }
        

    }


}
