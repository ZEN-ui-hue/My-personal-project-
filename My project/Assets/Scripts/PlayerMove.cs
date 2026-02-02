using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 9f;
    [SerializeField] private float jumpPower = 2f;

    private Rigidbody rb;
    private float rayDistance = 1.5f;
    private bool isGround;
    private bool clicked;

    public float currentSpeed { get; private set; }
    public bool isRunning { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance);

        if (Physics.Raycast(ray, rayDistance))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
            clicked = Input.GetKeyDown(KeyCode.Space);
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

        Vector3 jump = Vector3.up * jumpPower;

        if(clicked && isGround)
        {
            rb.AddForce(jump, ForceMode.Impulse);
            clicked = false;
        }
    }
}
