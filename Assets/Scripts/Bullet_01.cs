using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Bullet_01 : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    //[SerializeField] PhotonView healthBar1pView;
    //[SerializeField] PhotonView healthBar2pView;
    //public Image healthBar1;
    //public Image healthBar2;
    //public int currentHealth;
    public float bulletDamage = 1f;

    private void Awake()
    {
        
    }
    private void Start()
    {
        photonView = this.gameObject.GetComponent<PhotonView>();
        //healthBar1 = GameObject.Find("HPBAR Fill 1").GetComponent<Image>();
        //healthBar2 = GameObject.Find("HPBAR Fill 2").GetComponent<Image>();
        //healthBar1pView = healthBar1.GetComponent<PhotonView>();
        //healthBar2pView = healthBar2.GetComponent<PhotonView>();
        //currentHealth = FindObjectOfType<PlayerCombat>().currentHealth;
    }
    //private void Update()
    //{
        
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //PhotonView target = collision.gameObject.GetComponent<PhotonView>();
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Player")
        {
            PhotonNetwork.Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetPhotonView().RPC("RPC_DamageTaken", RpcTarget.All, bulletDamage);
           
            //calling collision object's player combat script's takedamage function for decrementing health
            //on collision
            
            Debug.Log("PLAYER HEALTH : " + collision.gameObject.GetComponent<PlayerCombat>().currentHealth);
            if (collision.gameObject.GetComponent<PlayerCombat>().currentHealth <= 1)
            {
                Destroy(collision.gameObject);

            }

        }

    }

    

    

}
