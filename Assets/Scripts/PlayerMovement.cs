using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    MyInputActions m_actions;
    private Vector2 inputVector;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Animator playerAnim;
    [SerializeField] float jumpForce = 0.5f;
    [SerializeField] bool jumpPressed;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] public Rigidbody2D rb2d;
    [SerializeField] float rayDistance = 0.5f;
    private Camera cam;
    private Vector3 offset;

    private void Awake()
    {
        m_actions = new MyInputActions();
        
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        offset = cam.transform.position - transform.position;
        
    }
    private void OnEnable()
    {
        m_actions.Player.Enable();
    }
    private void OnDisable()
    {
        m_actions.Player.Enable();
    }
    private void FixedUpdate()
    {
        Jump();
    }
    private void Update()
    {
        Move();
        
        cam.transform.position = transform.position + offset;

    }

    private void Jump()
    {
        jumpPressed = m_actions.Player.Jump.WasPressedThisFrame();
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance);
        if (jumpPressed && isGrounded)
        {
            
            //Debug.Log("JUMPED");
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
   

    private void Move()
    {
        inputVector = m_actions.Player.Move.ReadValue<Vector2>();
        if (inputVector.x != 0)
        {
            playerAnim.SetBool("IsWalking", true);

        }
        else
        {
            playerAnim.SetBool("IsWalking", false);
        }
        transform.Translate(inputVector.x * moveSpeed * Time.deltaTime, 0, 0);
    }
}
