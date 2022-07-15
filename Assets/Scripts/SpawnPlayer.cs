using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Spine;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PhotonView spawnPView;
    [SerializeField] float minX1, maxX1, minX2, maxX2, posY;
    [SerializeField] Material bluePlayerMat;
    [SerializeField] Material orangePlayerMat;
    [SerializeField] Color blueColor;
    [SerializeField] Color orangeColor;
    GameObject player1Temp;
    GameObject player2Temp;

    Vector2 randomPos1, randomPos2;
    // Start is called before the first frame update
    void Start()
    {
        //print(PhotonNetwork.LocalPlayer.ActorNumber);
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            randomPos1 = new Vector2(Random.Range(minX1, maxX1), posY);
            player1Temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPos1, Quaternion.identity);
            player1Temp.GetComponent<Renderer>().materials[0].SetColor("_Color", new Color(0f, 1.0f, 0.0f, 1.0f));
            //player1Temp.GetComponent<Renderer>().material.SetColor("_Color", blueColor);
            //Debug.Log(player1Temp.GetComponent<Renderer>().materials[0].GetColor("_Color"));
            //Debug.Log(player1Temp.GetComponent<Renderer>().material.GetColor("_TintColor"));
            //Debug.Log(player1Temp.GetComponent<Renderer>().material.GetColor("Tint Color"));





        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            randomPos2 = new Vector2(Random.Range(minX2, maxX2), posY);
            player2Temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPos2, Quaternion.identity);
            player2Temp.GetComponent<Renderer>().materials[0].SetColor("_Color", orangeColor);
            //player2Temp.GetComponent<Renderer>().material.SetColor("_Color", orangeColor);
            //Debug.Log(player2Temp.GetComponent<Renderer>().materials[0].GetColor("_Color"));



        }


    }

    // Update is called once per frame
    void Update()
    {
        spawnPView.RPC("RPC_PlayerColor", RpcTarget.AllBuffered);

    }
    [PunRPC]
    public void RPC_PlayerColor()
    {
        if(spawnPView.IsMine)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                player1Temp.GetComponent<MeshRenderer>().material = bluePlayerMat;
                //Debug.Log(player1Temp.GetComponent<Renderer>().materials[0].GetColor("_Color"));
            }
            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                player2Temp.GetComponent<MeshRenderer>().material = orangePlayerMat;
                Debug.Log(player2Temp.GetComponent<Renderer>().materials[0].GetColor("_Color"));
            }
        }
        
    }
}
