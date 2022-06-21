using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    MyInputActions myInputActions;
    Rigidbody2D rb2d;
    NewPlayerController newPlayerCont;
    [SerializeField] public bool meleeWeaponSeleceted = false;
    private void Awake()
    {
        myInputActions = new MyInputActions();
        rb2d = GetComponent<Rigidbody2D>();
        
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
        if(myInputActions.Player.MeleeWeapon.WasPressedThisFrame())
        {
            meleeWeaponSeleceted = !meleeWeaponSeleceted;
            animator.SetBool("meleeSeleceted", meleeWeaponSeleceted);
        }
        if(meleeWeaponSeleceted == true)
        {
            if(rb2d.velocity.x!=0 && rb2d.velocity.y==0)
            {
                animator.SetBool("meleeWalking", true);
                if(rb2d.velocity.x>0)
                {
                    this.transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
                }
                if (rb2d.velocity.x < 0)
                {
                    this.transform.localScale = new Vector3(-0.3f, 0.3f, 1.0f);
                }
            }
            else if(rb2d.velocity.x == 0 && rb2d.velocity.y ==0)
            {
                animator.SetBool("meleeWalking", false);

            }
            //else if(rb2d.velocity.y!=0)
            //{
            //    animator.SetBool("meleeJumping", true);
            //}
        }
        
    }
}
