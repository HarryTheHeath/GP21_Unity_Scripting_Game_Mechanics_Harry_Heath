using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 50f;
    private Rigidbody myRigidBody;
    private enum KeyState { Off, Down, Held, Up } 
    private KeyState ksHorizontal = KeyState.Off;
    private KeyState ksSpace = KeyState.Off;

    private void Awake()
    {
        myRigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Move left and right Inputs
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            ksHorizontal = KeyState.Down;
        } 
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            ksHorizontal = KeyState.Up;
        }
        
        // Jumping inputs

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ksSpace = KeyState.Down;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ksSpace = KeyState.Up;
        }
    }

    private void FixedUpdate()
    {
        // Jumping logic
        
        switch (ksSpace)
        {
            case KeyState.Down:
            {
                ksSpace = KeyState.Held;
                break;
            }
            case KeyState.Held:
                // Holding "Jump"
                if (myRigidBody.velocity.y == 0)
                {
                    Debug.Log("Jump");
                    myRigidBody.AddForce(Vector3.up * jumpForce);
                }
                break;
            case KeyState.Off:
                break;
            case KeyState.Up:
                // "Jump" released
                ksSpace = KeyState.Off;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
