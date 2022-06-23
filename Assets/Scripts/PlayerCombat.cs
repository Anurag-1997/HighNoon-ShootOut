using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    AudioSource audioSource;
    [SerializeField] AudioClip meleeSwooshAudioClip;
    MyInputActions myInputActions;
    Rigidbody2D rb2d;
    NewPlayerController newPlayerCont;
    public PhotonView pview;
    [SerializeField] LayerMask playerLayer;
    Collider2D[] hitEnemies;

    [SerializeField] public bool meleeWeaponSeleceted = false;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int Health = 50;
    private float animDelay;
    bool isAttacking = false;

    const string PLAYER_IDLE = "Idle_1";
    const string PLAYER_IDLE_MELEE = "Idle_Melee";
    const string PLAYER_WALK_MELEE = "Walk_Melee";
    const string PLAYER_JUMP_MELEE = "Jump_Melee";
    const string PLAYER_ATTACK_MELEE = "Attack_Melee";
    const string PLAYER_DAMAGE_MELEE = "Damage_Melee";
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
            hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer.value);
            myInputActions.Player.MeleeWeapon.performed += MeleeWeapon_performed;
            meleeAttack();
            myInputActions.Player.Jump.started += Jump_started;
            myInputActions.Player.Fire.performed += Fire_performed;
            

        }
        

    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        if(meleeWeaponSeleceted == true)
        {
            animator.Play(PLAYER_JUMP_MELEE);
        }
        
    }

    private void MeleeWeapon_performed(InputAction.CallbackContext obj)
    {
        
        meleeWeaponSeleceted = !meleeWeaponSeleceted;
        if(meleeWeaponSeleceted == true)
        {
            animator.Play(PLAYER_IDLE_MELEE);
        }
        else
        {
            animator.Play(PLAYER_IDLE);
        }
        
    }

    private void Fire_performed(InputAction.CallbackContext obj)
    {
        if(meleeWeaponSeleceted == true)
        {
            
            if(!isAttacking)
            {
                
                animator.Play(PLAYER_ATTACK_MELEE,0,0.5f);
                animDelay = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("AnimComplete", animDelay);
                audioSource.PlayOneShot(meleeSwooshAudioClip);

            }
            //foreach (Collider2D enemy in hitEnemies)
            //{
            //    if (enemy.transform.root != transform)
            //    {
            //        Debug.Log("Health : " + enemy.GetComponent<PlayerCombat>().Health);
            //        enemy.GetComponent<PlayerCombat>().Health -= 1;
            //        enemy.GetComponent<Animator>().Play(PLAYER_DAMAGE_MELEE);
            //    }
            //}
        }
    }

    private void meleeAttack()
    {
        
        if (meleeWeaponSeleceted == true)
        {
            if (rb2d.velocity.x != 0)
            {
                animator.Play(PLAYER_WALK_MELEE);
                
            }
            else if (rb2d.velocity.x == 0)
            {
                animator.Play(PLAYER_IDLE_MELEE);

            }
            

        }
    }
    private void AnimComplete()
    {
        isAttacking = false;
    }
}
