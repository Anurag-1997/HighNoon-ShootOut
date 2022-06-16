using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] float minX, maxX, posY;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), posY);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
