using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 9f;

    private Rigidbody rb;

    public float currentSpeed { get; private set; }
    public bool isRunning { get; private set; }

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

        Vector3 moveDir = (camForward.normalized * v + camRight.normalized * h).normalized;

        isRunning = Input.GetKey(KeyCode.LeftShift) && v > 0;

        float targetSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveDir.x * targetSpeed;
        velocity.z = moveDir.z * targetSpeed;
        rb.linearVelocity = velocity;

        Vector3 flatVelocity = new Vector3(velocity.x, 0, velocity.z);
        currentSpeed = flatVelocity.magnitude;
    }
}
