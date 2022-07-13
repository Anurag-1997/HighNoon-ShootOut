using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] float minX1, maxX1,minX2,maxX2, posY;
   
    Vector2 randomPos1,randomPos2;
    // Start is called before the first frame update
    void Start()
    {
        //print(PhotonNetwork.LocalPlayer.ActorNumber);
        if(PhotonNetwork.LocalPlayer.ActorNumber==1)
        {
            randomPos1 = new Vector2(Random.Range(minX1, maxX1), posY);
            PhotonNetwork.Instantiate(playerPrefab.name, randomPos1, Quaternion.identity);
            
        }
        if(PhotonNetwork.LocalPlayer.ActorNumber==2)
        {
            randomPos2 = new Vector2(Random.Range(minX2, maxX2), posY);
            PhotonNetwork.Instantiate(playerPrefab.name, randomPos2, Quaternion.identity);
           
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
