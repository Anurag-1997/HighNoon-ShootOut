using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class NewPlayerController : MonoBehaviour
{
    MyInputActions m_Actions;
    NewPlayerController newPlayercont;
    Vector2 moveVector;
    [SerializeField] float moveSpeed = 1f,jumpForce=1f;
    [SerializeField] Animator anim;
    Rigidbody2D rb2d;
    PlayerCombat playerCombat;

    private void Awake()
    {
        m_Actions = new MyInputActions();
        rb2d = GetComponent<Rigidbody2D>();
        playerCombat = GetComponent<PlayerCombat>();    
    }
    private void OnEnable()
    {
        m_Actions.Player.Enable();
    }
    private void OnDisable()
    {
        m_Actions.Player.Disable();
    }
    private void Move()
    {
        moveVector = m_Actions.Player.Move.ReadValue<Vector2>();
        rb2d.velocity = new Vector2(moveVector.x * moveSpeed, rb2d.velocity.y);
        if (moveVector.x != 0)
        {
            if (!playerCombat.meleeWeaponSeleceted)
            {
                anim.SetBool("isWalking", true);
                if (moveVector.x < 0)
                {
                    
                    transform.localScale = new Vector3(-0.3f, 0.3f, 1);
                }
                else if (moveVector.x > 0)
                {
                    transform.localScale = new Vector3(0.3f, 0.3f, 1);
                }
                else if (rb2d.velocity.x != 0 && rb2d.velocity.y != 0)
                {
                    anim.SetBool("isWalking", false);

                }
            }
        }
       
        else if(moveVector.x == 0)
        {
            anim.SetBool("isWalking", false);
        }
        
    }
    private void Jump()
    {
        if(m_Actions.Player.Jump.WasPressedThisFrame())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            anim.SetBool("isJumping", true);
           
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
       
       
       
    }
    private void Update()
    {
        Move();
        Jump();
    }
}
