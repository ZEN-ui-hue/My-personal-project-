using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private Collider monsterCollider;
    public bool isAttack { get; private set; }
    private int damage = 5;

    void Start()
    {
        monsterCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isAttack = true;

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealth.TakeDamage(damage);
        }
    }
}
