using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet_01 : MonoBehaviour
{
    [SerializeField] PhotonView pview;
    //public int currentHealth;
    public int bulletDamage = 1;

    private void Awake()
    {
        
    }
    private void Start()
    {
        pview = GetComponent<PhotonView>();
        //currentHealth = FindObjectOfType<PlayerCombat>().currentHealth;
    }
    //private void Update()
    //{
        
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Player")
        {
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCombat>().TakeDamage(bulletDamage);
            Debug.Log("PLAYER HEALTH : " + collision.gameObject.GetComponent<PlayerCombat>().currentHealth); 
            if (collision.gameObject.GetComponent<PlayerCombat>().currentHealth <= 1)
            {
                Destroy(collision.gameObject);

            }
        }

    }

    //[PunRPC]
    //void RPC_TakeDamage1(int damage)
    //{
    //    if (!pview.IsMine)
    //    {
    //        return;
    //    }
    //    currentHealth -= damage;
    //}
    //public void TakeDamage1(int damage)
    //{
    //    pview.RPC("RPC_TakeDamage1", RpcTarget.All, bulletDamage);
    //}

}
