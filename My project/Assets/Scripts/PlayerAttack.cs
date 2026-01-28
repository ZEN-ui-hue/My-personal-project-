using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isShortShoot { get; private set;} = false;
    public bool isLongShoot { get; private set; } = false;
    public bool isAimming { get; private set; } = false;

    void Start()
    {
        
    }

    void Update()
    {
        isShortShoot = Input.GetKeyDown(KeyCode.Mouse0);
        isLongShoot = Input.GetKey(KeyCode.Mouse0);
        isAimming = Input.GetKey(KeyCode.Mouse1);
    }
}
