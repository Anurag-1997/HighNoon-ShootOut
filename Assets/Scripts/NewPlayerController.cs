using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Spine.Unity;

public class NewPlayerController : MonoBehaviourPun,IPunInstantiateMagicCallback
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

    [SerializeField] Material bluePlayerMat;
    [SerializeField] Material orangePlayerMat;
    //public Material[] materials;
    [SerializeField] public Shader tintShader;
    public MeshRenderer meshRenderer;

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
        //spawnPlayer = FindObjectOfType<SpawnPlayer>();
    }
    private void Start()
    {
        
        //meshRenderer.material.SetColor(Shader.PropertyToID("_Color"), Color.green);
        //Invoke("MatUpdate", 4f);
        
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
    void IPunInstantiateMagicCallback.OnPhotonInstantiate(Photon.Pun.PhotonMessageInfo info)
    {
        SpawnPlayer.instance.playerList.Add(this.gameObject);


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
        this.GetComponent<SkeletonMecanim>().OnMeshAndMaterialsUpdated += NewPlayerController_OnMeshAndMaterialsUpdated;
        
        //pview.RPC("AssignColorStrings", RpcTarget.All);
        //pview.RPC("ChangeMaterials", RpcTarget.All, materialIdentifier);
        //MatAssignFunction();






    }

    private void NewPlayerController_OnMeshAndMaterialsUpdated(SkeletonRenderer skeletonRenderer)
    {
        for (int i = 0; i < SpawnPlayer.instance.playerList.Count; i++)
        {
            if(SpawnPlayer.instance.playerList.Count ==1)
            {
                if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
                {
                    SpawnPlayer.instance.playerList[0].gameObject.GetComponent<MeshRenderer>().material = bluePlayerMat;
                    //SpawnPlayer.instance.playerList[1].gameObject.GetComponent<MeshRenderer>().material = orangePlayerMat;

                }
            }
            if (SpawnPlayer.instance.playerList.Count ==2)
            {
                if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
                {
                    SpawnPlayer.instance.playerList[0].gameObject.GetComponent<MeshRenderer>().material = bluePlayerMat;
                    SpawnPlayer.instance.playerList[1].gameObject.GetComponent<MeshRenderer>().material = orangePlayerMat;
                }
                if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
                {
                    SpawnPlayer.instance.playerList[1].gameObject.GetComponent<MeshRenderer>().material = bluePlayerMat;
                    SpawnPlayer.instance.playerList[0].gameObject.GetComponent<MeshRenderer>().material = orangePlayerMat;
                }
            }
            
            

        }
    }

    //private void MatUpdate()
    //{
    //    //Debug.LogError("Flag : ");
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        Debug.Log("Mat Update called");
    //        this.GetComponent<MeshRenderer>().materials[0] = bluePlayerMat;
    //    }
    //    //meshRenderer.materials[0] = bluePlayerMat;
    //}



    private void Jump_started(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            if (!playerCombat.meleeWeaponSeleceted && !playerCombat.weapon1Selected)
            {
                ChangeAnimState(PLAYER_JUMP);
            }




        }
    }
    //[PunRPC]
    //public void AssignColorStrings()
    //{
    //    for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
    //    {
    //        if (PhotonNetwork.PlayerList[i] == PhotonNetwork.PlayerList[0])
    //        {
    //            materialIdentifier = "Blue";
    //        }
    //        if (PhotonNetwork.PlayerList[i] == PhotonNetwork.PlayerList[1])
    //        {
    //            materialIdentifier = "Orange";
    //        }
    //    }
    //    if (materialIdentifier == "Blue")
    //    {

    //    }
    //    if (materialIdentifier == "Orange")
    //    {

    //    }


    //}

    //[PunRPC]
    //public void ChangeMaterials(string material)
    //{
    //    materialIdentifier = material;
    //}


}
