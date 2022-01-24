using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");
        rigidBody.velocity += new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);
    }
}
