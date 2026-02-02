using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private float runSpeed = 7f;

    public float currentSpeed { get; private set; }

    private Rigidbody rb;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        currentSpeed = runSpeed;
    }

    void FixedUpdate()
    {
        Vector3 direction = (player.position - gameObject.transform.position).normalized;
        gameObject.transform.LookAt(player);

        Vector3 velocity = rb.linearVelocity;
        velocity.x = direction.x * runSpeed;
        velocity.z = direction.z * runSpeed;
        rb.linearVelocity = velocity;

        Vector3 flatVelocity = new Vector3(velocity.x, 0, velocity.z);
        currentSpeed = flatVelocity.magnitude;
    }
}
