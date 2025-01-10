using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour
{

    public Vector3 camera_Offset = new Vector3(0f, 0f, 0f);
    private Transform target;

    void Start()
    {
        target = GameObject.Find("PLAYER").transform;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camera_Offset);
        this.transform.LookAt(target);
    }
}
