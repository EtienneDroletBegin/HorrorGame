using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float sensX;
    [SerializeField]private float sensY;
    [SerializeField]private Transform feetPos;

    private float xRotation;
    private float yRotation;

    [SerializeField]private Transform Orientation;

    private Animator animator;
    private Rigidbody m_playerRB;


    private void Start()
    {
        animator = GetComponent<Animator>();
        m_playerRB = Orientation.parent.GetComponent<Rigidbody>() ;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (m_playerRB.velocity.sqrMagnitude > 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("moving", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Orientation.transform.parent.GetComponent<PlayerMovement>().setSprintSpeed();
                animator.SetBool("sprinting", true);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                Orientation.transform.parent.GetComponent<PlayerMovement>().setCrouchSpeed();
                animator.SetBool("crouch", true);
            }
            else
            {
                Orientation.transform.parent.GetComponent<PlayerMovement>().setWalkSpeed();
                animator.SetBool("sprinting", false);
                animator.SetBool("crouch", false);
            }
        }
        else
        {
            animator.SetBool("moving", false);
        }

        float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mousex;
        xRotation -= mousey;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    public void PlayFootStep()
    {
        AudioManager.GetInstance().PlaySound("footstep", transform.position);
        GetComponent<CreateSoundWave>().Create(feetPos) ;
    }
}
