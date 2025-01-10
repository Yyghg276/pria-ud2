using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
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
