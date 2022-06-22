using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    AudioSource audioSource;
    [SerializeField] AudioClip meleeSwooshAudioClip;
    MyInputActions myInputActions;
    Rigidbody2D rb2d;
    NewPlayerController newPlayerCont;
    [SerializeField] public bool meleeWeaponSeleceted = false;
    public PhotonView pview;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int Health = 50;
    [SerializeField] LayerMask playerLayer;
    private void Awake()
    {
        myInputActions = new MyInputActions();
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        pview = GetComponent<PhotonView>();
        
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
        if(pview.IsMine)
        {
            meleeAttack();
            pview.RPC("RPC_MeleeDamage", RpcTarget.All);

        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(meleeWeaponSeleceted)
            {
                if(myInputActions.Player.Fire.WasPressedThisFrame())
                {
                    Debug.Log("Player was hit!!!");
                }

            }
        }
    }

    [PunRPC]
    public void RPC_MeleeDamage()
    {
        animator.SetTrigger("meleeDamage");
    }

    private void meleeAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer.value);
        if (myInputActions.Player.MeleeWeapon.WasPressedThisFrame())
        {
            meleeWeaponSeleceted = !meleeWeaponSeleceted;
            animator.SetBool("meleeSeleceted", meleeWeaponSeleceted);
        }
        if (meleeWeaponSeleceted == true)
        {
            if (rb2d.velocity.x != 0)
            {
                animator.SetBool("meleeWalking", true);
                if (rb2d.velocity.x > 0)
                {
                    this.transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
                }
                if (rb2d.velocity.x < 0)
                {
                    this.transform.localScale = new Vector3(-0.3f, 0.3f, 1.0f);
                }
            }
            else if (rb2d.velocity.x == 0)
            {
                animator.SetBool("meleeWalking", false);

            }
            else if (rb2d.velocity.y != 0)
            {
                animator.SetBool("meleeJumping", true);
            }
            if (rb2d.velocity.y == 0)
            {
                animator.SetBool("meleeJumping", false);
            }
            if (myInputActions.Player.Fire.WasPressedThisFrame())
            {
                animator.SetBool("meleeAttacking", true);
                audioSource.PlayOneShot(meleeSwooshAudioClip);
            }
            else if (myInputActions.Player.Fire.WasReleasedThisFrame())
            {
                animator.SetBool("meleeAttacking", false);
            }
            foreach (Collider2D enemy in hitEnemies)   
            {
                if (enemy.transform.root != transform)
                {
                   if(myInputActions.Player.Fire.WasPressedThisFrame())
                   {
                        Debug.Log("Health : " + enemy.GetComponent<PlayerCombat>().Health);
                        enemy.GetComponent<PlayerCombat>().Health -= 1;
                        enemy.GetComponent<PlayerCombat>().RPC_MeleeDamage();
                   }
                }
            }

        }
    }
}
