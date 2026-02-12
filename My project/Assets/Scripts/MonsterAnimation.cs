using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    private Animator animator;
    private MonsterMove monsterMove;
    private MonsterAttack monsterAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
        monsterMove = GetComponent<MonsterMove>();
        monsterAttack = GetComponent<MonsterAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", monsterMove.currentSpeed);
        animator.SetBool("IsAttack", monsterAttack.isAttack);
    }
}
