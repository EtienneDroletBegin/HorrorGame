using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    private float maxSize;
    public void setMaxSize(float size)
    {
        maxSize = size;
    }

    private void Update()
    {
        transform.localScale += new Vector3(0.2f, 0f, 0.2f);
        if(transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("monster"))
        {
            print("he heard you");
            other.GetComponent<monster>().NewDestination(transform.position);
        }
    }
}
