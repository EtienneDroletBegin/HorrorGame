using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private bool hasObject = false;

    [SerializeField]
    private Transform orientation;
    private Ray faceRay;

    [SerializeField]
    private GrabbableObject TargetBody;



    private void Update()
    {
        faceRay = new Ray();
        faceRay.origin = Camera.main.transform.position;
        faceRay.direction = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (hasObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TargetBody.Throw(Camera.main.transform.forward.normalized);
                TargetBody = null;
                hasObject = false;
                return;
            }
        }

        if (Physics.Raycast(faceRay, out hitInfo, 3))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hitInfo.collider.CompareTag("Grabbable"))
                {
                    TargetBody = hitInfo.collider.GetComponent<GrabbableObject>();
                    TargetBody.Grab();
                    hasObject = true;

                }
            }
        }
    }



}
