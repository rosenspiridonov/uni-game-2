using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        rb.linearVelocity = -Vector3.forward * speed;
    }
}
