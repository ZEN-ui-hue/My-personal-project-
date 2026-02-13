using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }
}
