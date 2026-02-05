using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isShortShoot { get; private set;} = false;
    public bool isLongShoot { get; private set; } = false;
    public bool isAiming { get; private set; } = false;

    void Start()
    {
        
    }

    void Update()
    {
        isAiming = Input.GetKey(KeyCode.Mouse1);
        isShortShoot = Input.GetKeyDown(KeyCode.Mouse0);
        isLongShoot = Input.GetKey(KeyCode.Mouse0);
    }

    public void StopAiming()
    {
        isAiming = false;
    }
}
