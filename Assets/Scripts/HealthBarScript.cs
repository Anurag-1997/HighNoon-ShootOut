using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Image healthBarImage1;
    [SerializeField] private Image healthBarImage2;
    //[SerializeField] GameObject player;
    PlayerCombat playerCombat1;
    public GameObject player;
    public PhotonView pView;
    private float maxHealth = 50;
    float currentHealth;
    private void Start()
    {
        playerCombat1 = player.GetComponent<PlayerCombat>();
        pView = player.GetPhotonView();

    }
    private void Update()
    {
        if(PhotonNetwork.LocalPlayer.ActorNumber==1)
        {
            currentHealth = playerCombat1.currentHealth;
            healthBarImage1.fillAmount = currentHealth / playerCombat1.maxHealth;
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            currentHealth = playerCombat1.currentHealth;
            healthBarImage2.fillAmount = currentHealth / playerCombat1.maxHealth;
        }
        //currentHealth = playerCombat1.Health;
        //healthBarImage.fillAmount = currentHealth / maxHealth;

    }


}
