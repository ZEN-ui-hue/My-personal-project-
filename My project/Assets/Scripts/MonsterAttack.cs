using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public bool isAttack { get; private set; }
    private Collider monsterCollider;

    void Start()
    {
        monsterCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isAttack = true;
        }
    }
}
