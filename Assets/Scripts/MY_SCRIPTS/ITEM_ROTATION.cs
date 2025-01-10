using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM_ROTATION : MonoBehaviour
{

    public int rotation_Speed = 100;
    private Transform itemTransform;

    void Start()
    {
        itemTransform = this.GetComponent<Transform>();
    }

    void Update()
    {
        itemTransform.Rotate(rotation_Speed * Time.deltaTime,0,0);
    }
}
