using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class NewPlayerController : MonoBehaviour
{
    MyInputActions m_Actions;
    NewPlayerController newPlayercont;
    [SerializeField] Animator anim;
    Rigidbody2D rb2d;
    PlayerCombat playerCombat;
    [SerializeField] LayerMask groundLayer;
    public PhotonView pview;

    [SerializeField] float moveSpeed = 1f,jumpForce=1f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] private Transform feetPositon;
    [SerializeField] private float rayDistance;
    private float animDelay;
    Vector2 moveVector;


    private string currentState;
    const string PLAYER_IDLE = "Idle_1";
    const string PLAYER_WALK = "Walk_1";
    const string PLAYER_JUMP = "Jump_1";

    private void Awake()
    {
        m_Actions = new MyInputActions();
        rb2d = GetComponent<Rigidbody2D>();
        playerCombat = GetComponent<PlayerCombat>();
        pview = GetComponent<PhotonView>();
    }
    private void OnEnable()
    {
        m_Actions.Player.Enable();
    }
    private void OnDisable()
    {
        m_Actions.Player.Disable();
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;

    }
    private void Move()
    {
        moveVector = m_Actions.Player.Move.ReadValue<Vector2>();
        rb2d.velocity = new Vector2(moveVector.x * moveSpeed, rb2d.velocity.y);
        if (moveVector.x < 0)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1);
        }
        else if (moveVector.x > 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
        if(isGrounded && !playerCombat.meleeWeaponSeleceted)
        { 
            if(moveVector.x != 0)
            {
                ChangeAnimationState(PLAYER_WALK);  
            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }

        
        
        
    }
    
    private void Update()
    {
        if(pview.IsMine)
        {
            isGrounded = Physics2D.Raycast(feetPositon.position, Vector2.down, rayDistance, groundLayer.value);
            Debug.DrawRay(feetPositon.position, Vector2.down * rayDistance, Color.white);
            Move();
            m_Actions.Player.Jump.started += Jump_started;
            


        }
    }

    private void Jump_started(InputAction.CallbackContext context)
    {
        if (isGrounded )
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            if(!playerCombat.meleeWeaponSeleceted)
            {
                ChangeAnimationState(PLAYER_JUMP);
            }

            


        }
    }
}
