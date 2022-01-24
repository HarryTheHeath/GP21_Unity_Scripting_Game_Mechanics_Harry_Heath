using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 50f;
    private Rigidbody myRigidBody;

    private void Awake()
    {
        myRigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        // Preferably get input in Update()
        var moveInput = Input.GetAxis("Horizontal");
        
        // set move Input
        // Preferably interact with physics in FixedUpdate()
        myRigidBody.velocity += new Vector3(moveInput * moveSpeed * myRigidBody.velocity.y, 0);
        
        // Get Jump Input
        // Preferably get input in Update()
        var jumpInput = Input.GetKeyDown(KeyCode.Space);
        if (jumpInput & myRigidBody.velocity.y == 0)
            myRigidBody.AddForce(Vector3.up * jumpForce);
    }

}
