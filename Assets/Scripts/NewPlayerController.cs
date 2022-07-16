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
    //[SerializeField] public Color bluePlayer;
    //[SerializeField] public Color OrangePlayer;
    SpawnPlayer spawnPlayer;
    //[SerializeField] Material bluePlayerMat;
   // [SerializeField] Material orangePlayerMat;
    public Material[] materials;

    [SerializeField] float moveSpeed = 1f,jumpForce=1f;
    [SerializeField] private bool isGrounded = false;
    //[SerializeField] bool jumpPressed = false;
    [SerializeField] private Transform feetPositon;
    [SerializeField] private float rayDistance;
    string materialIdentifier;

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
        spawnPlayer = FindObjectOfType<SpawnPlayer>();
    }
    private void OnEnable()
    {
        m_Actions.Player.Enable();
    }
    private void OnDisable()
    {
        m_Actions.Player.Disable();
    }

    [PunRPC]
    public void ChangeAnimState(string newState)
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
        if(isGrounded && !playerCombat.meleeWeaponSeleceted && !playerCombat.weapon1Selected)
        { 
            if(moveVector.x != 0)
            {
                ChangeAnimState(PLAYER_WALK);  
            }
            else
            {
                ChangeAnimState(PLAYER_IDLE);
            }
        }

        
        
        
    }
    
    private void Update()
    {
        if (pview.IsMine)
        {

            //this.gameObject.GetComponent<MeshRenderer>().material.color = bluePlayer;
            pview.RPC("ChangeAnimState", RpcTarget.All, currentState);
            isGrounded = Physics2D.Raycast(feetPositon.position, Vector2.down, rayDistance, groundLayer.value);
            Debug.DrawRay(feetPositon.position, Vector2.down * rayDistance, Color.white);
            Move();
            m_Actions.Player.Jump.started += Jump_started;

            

        }
        pview.RPC("AssignColorStrings", RpcTarget.All);
        pview.RPC("ChangeMaterials", RpcTarget.All, materialIdentifier);
        MatAssignFunction();






    }

    public void MatAssignFunction()
    {
        if (materialIdentifier == "Blue")
        {
            spawnPlayer.player1Temp.GetComponent<MeshRenderer>().material = materials[0];
        }
        if (materialIdentifier == "Orange")
        {
            spawnPlayer.player2Temp.GetComponent<MeshRenderer>().material = materials[1];
        }
        
    }

    private void Jump_started(InputAction.CallbackContext context)
    {
        if (isGrounded )
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            if(!playerCombat.meleeWeaponSeleceted && !playerCombat.weapon1Selected)
            {
                ChangeAnimState(PLAYER_JUMP);
            }

            


        }
    }
    [PunRPC]
    public void AssignColorStrings()
    {
        if(PhotonNetwork.LocalPlayer.ActorNumber==1)
        {
            materialIdentifier = "Blue";
        } 
        if(PhotonNetwork.LocalPlayer.ActorNumber==2)
        {
            materialIdentifier = "Orange";
        }
    
    }

    [PunRPC]
    public void ChangeMaterials(string material)
    {
        materialIdentifier = material;
    }
    
    
}
