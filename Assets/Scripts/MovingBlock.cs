using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{

    [SerializeField] float lengthY;
    [SerializeField] float speedY;
    [SerializeField] float lengthX;
    [SerializeField] float speedX;

    [SerializeField] bool negY = false;
    [SerializeField] bool negX = false;
   

    void Update()
    {

        PingPongY();
        PingPongX();

        
       
            
        
    }

    void PingPongY()
    {
        if (!negY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time * speedY, 1) * lengthY, transform.localPosition.z);
        }else if (negY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -Mathf.PingPong(Time.time * speedY, 1) * lengthY, transform.localPosition.z);
        }
    }
    void PingPongX()
    {
        transform.localPosition = new Vector3(Mathf.PingPong(Time.time * speedX, 1) * lengthX, transform.localPosition.y, transform.localPosition.z);
    }
}
