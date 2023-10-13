using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private bool isGrabbed = false;

    [SerializeField] private Transform m_player;
    private float magnitude; 


    private void Update()
    {
        if (isGrabbed)
        {
            GetComponent<Collider>().enabled = false;
            transform.position = m_player.position;
            transform.forward = Camera.main.transform.forward;
        }



        magnitude = GetComponent<Rigidbody>().velocity.magnitude;
    }

    public void Grab()
    {
        isGrabbed = true;
    }

    public void Throw(Vector3 ThrowDirection)
    {
        GetComponent<Collider>().enabled = true;
        isGrabbed = false;
        GetComponent<Rigidbody>().velocity = ThrowDirection * 20;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isGrabbed && collision.collider.CompareTag("environment")) 
        {
            print(magnitude);
            GetComponent<CreateSoundWave>().Create(transform);
        }
    }
}
