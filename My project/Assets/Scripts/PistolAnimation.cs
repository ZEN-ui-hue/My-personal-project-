using UnityEngine;

public class PistolAnimation : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponentInParent<PlayerMove>();
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    void Update()
    {
        animator.SetFloat("Speed", playerMove.currentSpeed);
        animator.SetBool("IsRunning", playerMove.isRunning);
        animator.SetBool("IsAiming", playerAttack.isAimming);
        if(Input.GetMouseButtonDown(0))
        {
            if (playerAttack.isAimming)
            {
                animator.Play("AimFire", 0, 0f);
            }
            else
            {
               animator.Play("Fire", 0, 0f);
            }
        }
    }
}
