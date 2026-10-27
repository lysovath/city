using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float force = 100.0f;
    public float steerPower = 30.0f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current.wKey.isPressed)
        {
           moveObject(transform.forward); 
        }    
        if (Keyboard.current.sKey.isPressed)
        {
            moveObject(transform.forward * -1.0f);
        }
        float currentSpeed = Vector3.Dot(rb.linearVelocity, transform.forward);
        if(currentSpeed > 0.1f)
        {
            float isForward = currentSpeed > 0 ? 1f : -1f;
            float turnDirection = 0;
            if (Keyboard.current.aKey.isPressed)
            {
                turnDirection += -1f;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                turnDirection += 1f;
            }
            float rotationAmount = isForward * steerPower * turnDirection;

            transform.Rotate(0f, rotationAmount, 0f);
        }
    }

    void moveObject(Vector3 dir)
    {
        rb.AddForce(dir * force, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
