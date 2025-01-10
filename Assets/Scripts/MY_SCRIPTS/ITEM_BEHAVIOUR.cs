using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM_BEHAVIOUR : MonoBehaviour
{

    public Game_Behaviour GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GAME_MANAGER").GetComponent<Game_Behaviour>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PLAYER")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("ITEM COLLECTED!");
            GameManager.Items += 1;
        }
    }
}
