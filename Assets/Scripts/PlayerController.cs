using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerController: MonoBehaviour
{
    [SerializeField] SkeletonAnimation skelelonAnimation;
    [SerializeField] AnimationReferenceAsset idle,walking,jumping;
    [SerializeField] string currentState, currentAnimation, previousState;
    MyInputActions myInputAcitons;
    Vector2 moveVector;
    bool jumped = false;
    bool isGrounded = false;
    [SerializeField] float rayDistance = 0.1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform feetPositon;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float moveSpeed,jumpSpeed;
    PhotonView pview;
    
    

    private void Awake()
    {
        myInputAcitons = new MyInputActions();
    }
    private void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        pview = GetComponent<PhotonView>();
        currentState = "Idle";
        SetCharacterState(currentState);
    }
    private void Update()
    {
        //Move();
        if(pview.IsMine)
        {
            moveVector = myInputAcitons.Player.Move.ReadValue<Vector2>();
            jumped = myInputAcitons.Player.Jump.WasPressedThisFrame();
            isGrounded = Physics2D.Raycast(feetPositon.position, Vector2.down, rayDistance, groundMask.value);
            Debug.DrawRay(feetPositon.position, Vector2.down * rayDistance, Color.white);
        }
        

    }
    private void FixedUpdate()
    {
        if(pview.IsMine)
        {
            Move();
            pview.RPC("SetCharacterState", RpcTarget.All, currentState);
        }
        //pview.RPC("Move", RpcTarget.All);
        //pview.RPC("SetAnimation", RpcTarget.All,idle,);
        //pview.RPC("AnimationEntry_Complete", RpcTarget.All);
        
    }
    private void OnEnable()
    {
        myInputAcitons.Player.Enable();
    }
    private void OnDisable()
    {
        myInputAcitons.Player.Disable();
    }
    [PunRPC]
    public void SetAnimation(AnimationReferenceAsset animation,bool loop, float timeScale)
    {
        if(animation.name.Equals(currentAnimation))
        {
            return;
        }
        Spine.TrackEntry animationEntry = skelelonAnimation.state.SetAnimation(0, animation, loop);
        animationEntry.TimeScale = timeScale;
        animationEntry.Complete += AnimationEntry_Complete;
        currentAnimation = animation.name;
    }

    [PunRPC]
    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry)
    {
        if(currentState.Equals("Jumping"))
        {
            SetCharacterState(previousState);
        }
    }

    [PunRPC]
    public void SetCharacterState(string state)
    {
        
        if(state == "Walking")
        {
            SetAnimation(walking, true, 1f);
        }
        else if(state == "Jumping")
        {
            SetAnimation(jumping, false, 1f);
        }
        else
        {
            SetAnimation(idle, true, 1f);
        }
        currentState = state;
    }

    [PunRPC]
    public void Move()
    {
        
        rb2d.velocity = new Vector2(moveVector.x * moveSpeed, rb2d.velocity.y);
        if(moveVector.x != 0)
        {
            if(!currentState.Equals("Jumping"))
            {
                SetCharacterState("Walking");
            }
            if (moveVector.x > 0)
            {
                transform.localScale = new Vector2(0.25f, 0.25f);
            }
            else
            {
                transform.localScale = new Vector2(-0.25f, 0.25f);
            }
        }
        else
        {
            if (!currentState.Equals("Jumping"))
            {
                SetCharacterState("Idle");

            }
        }
        if(jumped && isGrounded)
        {
            Jump();
        }
        
    }
    public void Jump()
    {

        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        if(!currentState.Equals("Jumping"))
        {
            previousState = currentState;
        }
        SetCharacterState("Jumping");
    }
}
