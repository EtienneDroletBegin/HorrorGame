using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Transform orientation;
    [SerializeField]private float walkSpeed;
    [SerializeField]private float sprintSpeed;
    [SerializeField]private float crouchSpeed;

    private float speed;
    private float V;
    private float H;

    private Vector3 moveDir;

    private Rigidbody rb;

    public Rigidbody getRB() { return rb; }

    private void Start()
    {
        speed = walkSpeed;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        ProcessInput();
        Move();
    }

    public void setSprintSpeed()
    {
        speed = sprintSpeed;
    }

    public void setWalkSpeed()
    {
        speed = walkSpeed;
    }

    public void setCrouchSpeed()
    {
        speed = crouchSpeed;
    }

    private void ProcessInput()
    {
        V = Input.GetAxis("Vertical");
        H = Input.GetAxis("Horizontal");
    }


    private void Move()
    {
        moveDir = orientation.forward * V + orientation.right * H;
        rb.velocity = new Vector3(moveDir.x *speed, rb.velocity.y, moveDir.z*speed);
    }
}
