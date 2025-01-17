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

    public Transform Player;

    private int _lives = 3;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
        Player = GameObject.Find("PLAYER").transform;
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
        foreach (Transform child in Patrol_Route)
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
            agent.destination = Player.position;
            Debug.Log("ENEMY DETECTED!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "PLAYER")
        {
            Debug.Log("PLAYER OUT OF RANGE, RESUME PATROL");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 5
        if (collision.gameObject.name == "BULLET(Clone)")
        {
            // 6
            EnemyLives -= 1;
            Debug.Log("CRITICAL HIT!");
        }
    }

    public int EnemyLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("ENEMY DOWN");
            }
        }
    }
}