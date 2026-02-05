using UnityEngine;

public class AK47Animation : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.1f;
    private float nextFireTime = 0f;

    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponentInParent<PlayerMove>();
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", playerMove.currentSpeed);
        animator.SetBool("IsRunning", playerMove.isRunning);
        animator.SetBool("IsAiming", playerAttack.isAiming);
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            if (playerAttack.isAiming)
            {
                animator.Play("AimFire", 0, 0f);
            }
            else if(playerMove.isRunning == false)
            {
                animator.Play("Fire", 0, 0f);
            }
        }
    }
}
