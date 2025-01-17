using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behaviour : MonoBehaviour
{

    public Transform Patrol_Route;
    public List<Transform> Locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in Patrol_Route)
        {
            Locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
        return;
        agent.destination = Locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % Locations.Count;
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
