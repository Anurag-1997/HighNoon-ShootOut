using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] public Image healthBarImage1;
    [SerializeField] public Image healthBarImage2;
    //[SerializeField] GameObject player;
    PlayerCombat playerCombat1;
    public GameObject player;
    public PhotonView pView;
    //private float maxHealth = 50;
    //float currentHealth;
    private void Start()
    {
        playerCombat1 = player.GetComponent<PlayerCombat>();
        pView = GetComponent<PhotonView>();
    }
    private void Update()
    {

        //currentHealth = playerCombat1.Health;
        //healthBarImage.fillAmount = currentHealth / maxHealth;
        this.pView.RPC("RPC_HealthBarUpdate", RpcTarget.All, playerCombat1.currentHealth,playerCombat1.maxHealth);

    }

    [PunRPC]
    public void RPC_HealthBarUpdate(float currentHealth,float maxHealth)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            healthBarImage1.fillAmount = currentHealth / maxHealth;
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            healthBarImage2.fillAmount = currentHealth /maxHealth;
        }
    }


}
