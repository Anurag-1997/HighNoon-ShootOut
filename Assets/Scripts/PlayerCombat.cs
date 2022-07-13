using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    AudioSource audioSource;
    [SerializeField] AudioClip meleeSwooshAudioClip;
    [SerializeField] AudioClip bulletShootAudioClip;
    MyInputActions myInputActions;
    Rigidbody2D rb2d;
    NewPlayerController newPlayerCont;
    //public GameObject weaponWheelPanel;
    WeaponWheelController weaponWheelController;
    public PhotonView pview;
    //public PhotonView healthBar1pView;
    //public PhotonView healthBar2pView;
    [SerializeField] LayerMask playerLayer;
    Collider2D[] hitEnemies;
    //[SerializeField] public Image healthBarImage1;
    //[SerializeField] public Image healthBarImage2;
    //Collider2D[] hitEnemies2;



    [SerializeField] public bool meleeWeaponSeleceted = false;
    [SerializeField] public bool weapon1Selected = false;
    [SerializeField] Transform attackPoint1,shoot_Point;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] public float currentHealth = 99.9f;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float meleeDamage = 3f;
    //[SerializeField] public float pistolDamage = 1f;
    [SerializeField] GameObject bulletPrefab;
    private float animDelay;
    bool isAttacking = false;

    private string currentState;
    const string PLAYER_IDLE = "Idle_1";
    const string PLAYER_IDLE_MELEE = "Idle_Melee";
    const string PLAYER_WALK_MELEE = "Walk_Melee";
    const string PLAYER_RUN_MELEE = "Run_Melee";
    const string PLAYER_JUMP_MELEE = "Jump_Melee";
    const string PLAYER_ATTACK_MELEE = "Attack_Melee";
    const string PLAYER_DAMAGE_MELEE = "Damage_Melee";
    
    const string IDLE_PISTOL = "Idle_Pistol";
    const string WALK_PISTOL = "Walk_Pistol";
    const string RUN_PISTOL = "Run_Pistol";
    const string JUMP_PISTOL = "Jump_Pistol";
    const string SHOOT_PISTOL = "Shoot_Pistol";
    const string DAMAGE_PISTOL = "Damage_Pistol";
    private void Awake()
    {
        myInputActions = new MyInputActions();
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        pview = GetComponent<PhotonView>();
        weaponWheelController = FindObjectOfType<WeaponWheelController>();
        
    }
    private void Start()
    {
        //healthBarImage1 = GameObject.Find("HPBAR Fill 1").GetComponent<Image>();
        //healthBarImage2 = GameObject.Find("HPBAR Fill 2").GetComponent<Image>();
        //healthBar1pView = healthBarImage1.GetComponent<PhotonView>();
        //healthBar2pView = healthBarImage2.GetComponent<PhotonView>();
        
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
        if (pview.IsMine)
        {
            if (weaponWheelController != null)
            {
                switch (WeaponWheelController.weaponID)
                {
                    case 0: //nothing is selected
                        weaponWheelController.selectedItem.sprite = weaponWheelController.noImage;
                        break;
                    case 1: //Melee Weapon
                        meleeWeaponSeleceted = true;
                        weapon1Selected = false;
                        if(rb2d.velocity.x==0)
                        {
                            ChangeAnimationState(PLAYER_IDLE_MELEE);

                        }
                        Debug.Log("Melee Weapon");
                        break;
                    case 2: //Pistol
                        meleeWeaponSeleceted = false;
                        weapon1Selected = true;
                        if(rb2d.velocity.x==0)
                        {
                            ChangeAnimationState(IDLE_PISTOL);
                        }
                        Debug.Log("Pistol");
                        break;
                    case 3: //SMG 1
                        Debug.Log("SMG 1");
                        break;
                    case 4: //SMG 2
                        Debug.Log("SMG 2");
                        break;
                    case 5: //ShotGun
                        Debug.Log("ShotGun");
                        break;
                    case 6: //Rocket Launcher
                        Debug.Log("Rocket Launcher");
                        break;
                    case 7: //Grenede
                        Debug.Log("Grenede");
                        break;

                }
            }
            pview.RPC("ChangeAnimationState", RpcTarget.AllBuffered, currentState);
            hitEnemies = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange, playerLayer.value);
            //hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, playerLayer.value);
            myInputActions.Player.MeleeWeapon.started += MeleeWeapon_started;
            myInputActions.Player.Weapon1.started += Weapon1_started;
            WalkAnim();
            myInputActions.Player.Jump.started += Jump_started;
            myInputActions.Player.Fire.started += Fire_started;

            
            
        }

    }

    private void Weapon1_started(InputAction.CallbackContext obj)
    {
        weapon1Selected = !weapon1Selected;
        if(meleeWeaponSeleceted == true)
        {
            meleeWeaponSeleceted = false;
        }
        if (weapon1Selected == true)
        {
            ChangeAnimationState(IDLE_PISTOL);
        }
        if (weapon1Selected == false)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
    }
    [PunRPC]
    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;

    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        if(meleeWeaponSeleceted == true)
        {
            ChangeAnimationState(PLAYER_JUMP_MELEE);
        }
        
    }

    private void MeleeWeapon_started(InputAction.CallbackContext obj)
    {
        
        meleeWeaponSeleceted = !meleeWeaponSeleceted;
        if(weapon1Selected == true)
        {
            weapon1Selected = false;
        }
        if(meleeWeaponSeleceted==true)
        {
            ChangeAnimationState(PLAYER_IDLE_MELEE);
        }
        if(meleeWeaponSeleceted==false)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        
        
    }

    private void Fire_started(InputAction.CallbackContext obj)
    {
        if(meleeWeaponSeleceted == true)
        {
            if(!isAttacking)
            {
                isAttacking = true;
                ChangeAnimationState(PLAYER_ATTACK_MELEE);
                audioSource.PlayOneShot(meleeSwooshAudioClip);
                //animDelay = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("AnimComplete", 1f);


                foreach (Collider2D enemy in hitEnemies)
                {
                   if(transform.localScale.x == 0.3f)
                   {
                        if (enemy.transform.root != transform)
                        {
                            Debug.Log("Health : " + enemy.GetComponent<PlayerCombat>().currentHealth);
                            enemy.GetComponent<PlayerCombat>().TakeDamage(meleeDamage);
                            //HealthBarUpdate1();
                            enemy.GetComponent<PlayerCombat>().ChangeAnimationState(PLAYER_DAMAGE_MELEE);
                        }
                   }
                    
                }
                foreach (Collider2D enemy in hitEnemies)
                {
                    if(transform.localScale.x==-0.3f)
                    {
                        if (enemy.transform.root != transform)
                        {
                            Debug.Log("Health : " + enemy.GetComponent<PlayerCombat>().currentHealth);
                            enemy.GetComponent<PlayerCombat>().TakeDamage(meleeDamage);
                            //HealthBarUpdate2();
                            enemy.GetComponent<PlayerCombat>().ChangeAnimationState(PLAYER_DAMAGE_MELEE);
                        }
                    }
                }
            }

        }
        if(weapon1Selected == true)
        {
            if(rb2d.transform.localScale.x == 0.3f)
            {
                GameObject bulletTemp = PhotonNetwork.Instantiate(bulletPrefab.name, shoot_Point.position, Quaternion.identity);
                audioSource.PlayOneShot(bulletShootAudioClip);
                bulletTemp.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;

                

            }
            else if(rb2d.transform.localScale.x == -0.3f)
            {
                GameObject bulletTemp = PhotonNetwork.Instantiate(bulletPrefab.name, shoot_Point.position, Quaternion.Euler(new Vector3(0,0,180f)));
                audioSource.PlayOneShot(bulletShootAudioClip);
                bulletTemp.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
                

            }
            
        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Take Damage called");
        pview.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, damage);
        
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
       if(pview.IsMine)
       {
            currentHealth -= damage;
            Debug.Log("Current health :  " + currentHealth);
       }
       
    }

   


    [PunRPC]
    private void WalkAnim()
    {
        
        if (meleeWeaponSeleceted == true && weapon1Selected==false)
        {
            if (rb2d.velocity.x != 0)
            {
                ChangeAnimationState(PLAYER_RUN_MELEE);
                
            }
            else if (rb2d.velocity.x == 0)
            {
                ChangeAnimationState(PLAYER_IDLE_MELEE);

            }
            

        }
        if(weapon1Selected == true )
        {
            if (rb2d.velocity.x != 0)
            {
                ChangeAnimationState(RUN_PISTOL);

            }
            else if (rb2d.velocity.x == 0)
            {
                ChangeAnimationState(IDLE_PISTOL);

            }
        }
    }
    private void AnimComplete()
    {
        isAttacking = false;
    }
}
