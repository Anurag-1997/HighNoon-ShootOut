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

    [HideInInspector] public GameObject player1Temp;
    [HideInInspector] public GameObject player2Temp;
    [SerializeField] public List<GameObject> playerList = new List<GameObject>();
    public static SpawnPlayer instance;
    

    Vector2 randomPos1, randomPos2;
    private void Awake()
    {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
        
        
      
        ////print(PhotonNetwork.LocalPlayer.ActorNumber);
        //if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        //{
        //    randomPos1 = new Vector2(Random.Range(minX1, maxX1), posY);
        //    //object[] myCustomInitData = GetInitData();
        //    GameObject player1Temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPos1, Quaternion.identity);

        //    Debug.Log("Instantiation id of player 1 : " + player1Temp.GetPhotonView().InstantiationId);
        //    player1Temp.gameObject.tag = "Player1";
        //    //player1Temp.GetComponent<Renderer>().materials[0].SetColor("_Color", new Color(0f, 1.0f, 0.0f, 1.0f));
        //    //player1Temp.GetComponent<Renderer>().material.SetColor("_Color", blueColor);
        //    //Debug.Log(player1Temp.GetComponent<Renderer>().materials[0].GetColor("_Color"));
        //    //Debug.Log(player1Temp.GetComponent<Renderer>().material.GetColor("_TintColor"));
        //    //Debug.Log(player1Temp.GetComponent<Renderer>().material.GetColor("Tint Color"));

        //}
        //if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        //{
        //    randomPos2 = new Vector2(Random.Range(minX2, maxX2), posY);
        //    GameObject player2Temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPos2, Quaternion.identity);
        //    Debug.Log("Instantiation id of player 2 : " + player2Temp.GetPhotonView().InstantiationId);
        //    player2Temp.gameObject.tag = "Player2";
        //    //player2Temp.GetComponent<Renderer>().materials[0].SetColor("_Color", orangeColor);
        //    //player2Temp.GetComponent<Renderer>().material.SetColor("_Color", orangeColor);
        //    //Debug.Log(player2Temp.GetComponent<Renderer>().materials[0].GetColor("_Color"));
        //    // GameObject playerTemp1 = PhotonNetwork.Instantiate(playerPrefab.name, randomPos1, Quaternion.identity);


        //}


    }
    
    void Init()
    {
        Gobj = PhotonNetwork.Instantiate(playerPrefab.name, randomPos1, Quaternion.identity);
        //Invoke("Temp2", 5f);
        //Invoke("Temp", 6f);

    }
    public void Temp()
    {
        Debug.Log("INVOKE TEMP CALLED NOW!!!");
        for (int i = 0; i < playerList.Count; i++)
        {
            
            if (PhotonNetwork.LocalPlayer.ActorNumber ==1)
            {
                Debug.Log("ACtor number = " + PhotonNetwork.LocalPlayer.ActorNumber);
                playerList[0].gameObject.GetComponent<MeshRenderer>().material = bluePlayerMat;
                //playerList[1].gameObject.GetComponent<MeshRenderer>().material = orangePlayerMat;

            }
            if(PhotonNetwork.LocalPlayer.ActorNumber ==2)
            {
                //playerList[1].gameObject.GetComponent<MeshRenderer>().material = bluePlayerMat;
                //playerList[0].gameObject.GetComponent<MeshRenderer>().materials[0] = orangePlayerMat;

            }

        }
        
    }
    public void Temp2()
    {
        Debug.Log("INVOKE TEMP-2 CALLED NOW!!!");
        for (int i = 0; i < playerList.Count; i++)
        {
            if(playerList.Count == 1)
            {
                player1Temp = playerList[0].gameObject;
                tempMat1 = player1Temp.GetComponent<MeshRenderer>().material;
                tempMat1 = bluePlayerMat;
                randomPos1 = new Vector2(Random.Range(minX1, maxX1), posY);
                player1Temp.transform.position = randomPos1;
               
            }
            else if(playerList.Count == 2)
            {
                //player 1
                player1Temp = playerList[0].gameObject;
                tempMat1 = player1Temp.GetComponent<MeshRenderer>().material;
                tempMat1 = bluePlayerMat;
                randomPos1 = new Vector2(Random.Range(minX1, maxX1), posY);
                player1Temp.transform.position = randomPos1;
                //player 2
                player2Temp = playerList[1].gameObject;
                tempMat2 = player2Temp.GetComponent<MeshRenderer>().material;
                tempMat2 = orangePlayerMat;
                randomPos2 = new Vector2(Random.Range(minX2, maxX2), posY);
                player2Temp.transform.position = randomPos2;
            }
                
            
            

        }
    }
    private void Update()
    {
        //skeletonMecanim.OnMeshAndMaterialsUpdated += SkeletonMecanim_OnMeshAndMaterialsUpdated;
        
    }

    private void SkeletonMecanim_OnMeshAndMaterialsUpdated(SkeletonRenderer skeletonRenderer)
    {
        
    }
}
    
    

    
   
   
   
