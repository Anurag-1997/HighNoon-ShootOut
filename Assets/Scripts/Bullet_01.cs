using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet_01 : MonoBehaviour
{
    PhotonView pview;

    private void Awake()
    {
        pview = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Player")
        {
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCombat>().Health -= 1;
            Debug.Log("PLAYER HEALTH : " + collision.gameObject.GetComponent<PlayerCombat>().Health); 
            if (collision.gameObject.GetComponent<PlayerCombat>().Health <= 1)
            {
                Destroy(collision.gameObject);

            }
        }

    }

    
}
