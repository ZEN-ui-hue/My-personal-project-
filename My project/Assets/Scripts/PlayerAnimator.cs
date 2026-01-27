using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMove playerMove;
    private Animator animator;

    private float speed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", playerMove.currentSpeed);
        animator.SetBool("IsRunning", playerMove.isRunning);
    }
}
