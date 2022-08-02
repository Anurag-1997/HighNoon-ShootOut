using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine.Animations;
using Spine;
using Spine.Unity;
using Spine.Collections;
using UnityEngine.UI;
using TMPro;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    //[SerializeField] PhotonView spawnPView;
    [SerializeField] float minX1, maxX1, minX2, maxX2, posY;
    [SerializeField] public Material bluePlayerMat;
    [SerializeField] public Material orangePlayerMat;
    [HideInInspector]public Material tempMat1;
    [HideInInspector]public Material tempMat2;
    [SerializeField] Color blueColor;
    [SerializeField] Color orangeColor;
    public GameObject Gobj;
    public SkeletonRenderer skeletonRenderer;
    public SkeletonMecanim skeletonMecanim;
    public Material originalMaterial;
    
   
    public static bool spawned = false;
    public static float loadTimer = 6f;

    [HideInInspector] public GameObject player1Temp;
    [HideInInspector] public GameObject player2Temp;
    public GameObject readyPanel;
    public TMP_Text timerText;
    public TMP_Text readyText;
    [SerializeField] public List<GameObject> playerList = new List<GameObject>();
    public static SpawnPlayer instance;
    

    Vector2 randomPos1, randomPos2;
    private void Awake()
    {
        instance = this;
        readyPanel.gameObject.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Init();


    }
    private void Update()
    {
        loadTimer -= Time.deltaTime;
        timerText.text = "Game Starts in : "+ loadTimer.ToString(); 
        if(loadTimer<=0f)
        {
            readyPanel.gameObject.SetActive(false);
        }
    }

    void Init()
    {
        Gobj = PhotonNetwork.Instantiate(playerPrefab.name, randomPos1, Quaternion.identity);
        Invoke("Temp2", 5f);
        //Invoke("Temp", 6f);

    }
    public void Temp2()
    {
        Debug.Log("Temp 2 called now ");
        if (playerList.Count == 1)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                playerList[0].gameObject.tag = "Player1";
                playerList[0].gameObject.transform.position = new Vector3(Random.Range(minX1, maxX1), posY, 0);
                //SpawnPlayer.instance.playerList[1].gameObject.GetComponent<MeshRenderer>().material = orangePlayerMat;

            }
        }
        if (playerList.Count == 2)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                playerList[0].gameObject.tag = "Player1";
                playerList[1].gameObject.tag = "Player2";
                playerList[0].gameObject.transform.position = new Vector3(Random.Range(minX1, maxX1), posY, 0);
                playerList[1].gameObject.transform.position = new Vector3(Random.Range(minX2, minX2), posY, 0);
            }

            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                playerList[1].gameObject.tag = "Player1";
                playerList[0].gameObject.tag = "Player2";
                playerList[1].gameObject.transform.position = new Vector3(Random.Range(minX1, maxX1), posY, 0);
                playerList[0].gameObject.transform.position = new Vector3(Random.Range(minX2, minX2), posY, 0);
            }
        }
        Debug.Log(playerList[0].GetPhotonView().Owner.NickName);
        Debug.Log(playerList[1].GetPhotonView().Owner.NickName);
        
    }
    

    
}
    
    

    
   
   
   
