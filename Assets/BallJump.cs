using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{

    public float speed = 10;
    public float jumpPower = 10;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void MoveHorizontal(float force)
    {
        rb.AddForce(force * speed, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Not today");
        }
    }

public void MoveVertical(float force)
{
    rb.AddForce(0, 0, force * speed);
    if(Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Jumping");
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    else
    
        {
            Debug.Log("Not today");
        }
}
}