using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{

    public Transform Patrol_Route;
    public List<Transform> Locations;
    void Start()
    {
        InitializePatrolRoute();
    }

    void Update()
    {

    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in Patrol_Route)
        {
            Locations.Add(child);
        }
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PLAYER")
        {
            Debug.Log("PLAYER DETTECTED - ATTACK!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "PLAYER")
        {
            Debug.Log("PLAYER OUT OF RANGE, RESUME PATROL");
        }
    }
}
