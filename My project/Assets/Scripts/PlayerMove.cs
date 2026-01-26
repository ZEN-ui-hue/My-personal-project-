using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 move = (camForward.normalized * v + camRight.normalized * h) * speed;
        move.y = rb.linearVelocity.y;

        rb.linearVelocity = move;
    }
}
