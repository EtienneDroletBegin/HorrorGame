using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSoundWave : MonoBehaviour
{
    [SerializeField] private GameObject sound; 
    [SerializeField] private Transform feetPos; 
    public void Create(Transform pos)
    {
        GameObject newSound = Instantiate(sound);
        newSound.GetComponent<Expand>().setMaxSize(20f);
        if (GetComponent<GrabbableObject>())
        {
            print(GetComponent<Rigidbody>().velocity.magnitude);
        }

        newSound.transform.position = pos.position;
    }
    
    public void Footstep()
    {
        Create(feetPos);
    }

}
