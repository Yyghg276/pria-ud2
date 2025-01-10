using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    private float vertical_Input;
    private float horizontal_Input;

    private Rigidbody rb;

    public float JumpVelocity = 3f;
    private bool isJumping;

    public float DistanceToGround = 0.2f;
    public LayerMask GroundLayer;
    private CapsuleCollider col;

    public GameObject Bullet;
    public float bullet_Speed = 100f;
    private bool isShooting;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        vertical_Input = Input.GetAxis("Vertical") * moveSpeed;
        horizontal_Input = Input.GetAxis("Horizontal") * rotateSpeed;
        isJumping |= Input.GetKeyDown(KeyCode.Space);
        isShooting |= Input.GetKeyDown(KeyCode.Q);
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * horizontal_Input;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        rb.MovePosition(this.transform.position + this.transform.forward * vertical_Input * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);

        if (isJumping && IsGrounded())
        {
            rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        else
        {
            isJumping = false;
        }

        if (isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            BulletRB.velocity = this.transform.forward * bullet_Speed;
        }
        else
        {
            isShooting = false;
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }
}
