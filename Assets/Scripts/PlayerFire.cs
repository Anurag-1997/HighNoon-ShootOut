using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    MyInputActions myInputActions;
    bool firePressed;
    GameObject bulletTemp;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnLocationRight;
    [SerializeField] Transform bulletSpawnLocationLeft;
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] SpriteRenderer spriteRend;
    private void Awake()
    {
        myInputActions = new MyInputActions();
    }

    private void OnEnable()
    {
        myInputActions.Player.Enable();
    }
    private void OnDisable()
    {
        myInputActions.Player.Disable();
    }
    private void Update()
    {
        firePressed = myInputActions.Player.Fire.WasPressedThisFrame();
        if(firePressed)
        {
            
            if(spriteRend.flipX == true)
            {
                bulletTemp = Instantiate(bulletPrefab, bulletSpawnLocationLeft.position, Quaternion.Euler(0, 0, 180));
                bulletTemp.GetComponent<Rigidbody2D>().velocity = -(transform.right) * bulletSpeed;

            }
            else if(spriteRend.flipX == false)
            {
                bulletTemp = Instantiate(bulletPrefab, bulletSpawnLocationRight.position, Quaternion.identity);
                bulletTemp.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

            }
        }
    }
}
