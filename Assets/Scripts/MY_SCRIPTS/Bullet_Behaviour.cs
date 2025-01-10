using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour
{

    public float on_Screen_Delay = 3f;

    void Start()
    {
        Destroy(this.gameObject, on_Screen_Delay);
    }

    void Update()
    {
        
    }
}
