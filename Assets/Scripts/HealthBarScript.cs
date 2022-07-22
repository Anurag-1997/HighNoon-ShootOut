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
    
    private void Start()
    {
        
    }
    private void Update()
    {

        HealthBarUpdate();

    }
    void HealthBarUpdate()
    {
        if(SpawnPlayer.instance.playerList.Count == 2 )
        {
            if(PhotonNetwork.LocalPlayer.ActorNumber ==1)
            {
                healthBarImage1.fillAmount = SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().maxHealth;
                healthBarImage2.fillAmount = SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().maxHealth;
            }
            if(PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                healthBarImage1.fillAmount = SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().maxHealth;
                healthBarImage2.fillAmount = SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().maxHealth;
            }
            
        }

    }




}
