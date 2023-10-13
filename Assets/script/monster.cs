using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour
{
    public void NewDestination(Vector3 pos)
    {
        GetComponent<NavMeshAgent>().SetDestination(pos);
    }
}
