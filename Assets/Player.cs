using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float h = Input.GetAxis("Horizontal") * movementSpeed;
        float v = Input.GetAxis("Vertical") * movementSpeed;

        rb.velocity = new Vector2(h * Time.deltaTime, v * Time.deltaTime);
        /*
        Vector2 velocityVector = rb.velocity;

        if (h > 0.01f)
        {
            velocityVector.x = velocityVector.x + h;
        }
        else if (h < 0)
        {
            velocityVector.x = velocityVector.x - h;
        }
        if (v > 0.01f)
        {
            velocityVector.y = velocityVector.y + v;
        }
        else if (v < 0)
        {
            velocityVector.y = velocityVector.y - v;
        }

        rb.velocity = velocityVector;
        */
    }
}
