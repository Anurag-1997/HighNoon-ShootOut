using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Bullet_01 : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    
    //public Image healthBar1;
    //public Image healthBar2;
    
    public float bulletDamage = 1f;

    private void Awake()
    {

    }
    private void Start()
    {
        //photonView = this.gameObject.GetComponent<PhotonView>();
        //healthBar1 = GameObject.Find("HPBAR Fill 1").GetComponent<Image>();
        //healthBar2 = GameObject.Find("HPBAR Fill 2").GetComponent<Image>();
        
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            collision.gameObject.GetComponent<PlayerCombat>().TakeDamage(bulletDamage);
            Debug.Log("Bullet hit the player 1");
        }
        if(collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<PlayerCombat>().TakeDamage(bulletDamage);
            Debug.Log("Bullet hit player 2");
        }

    }





}
