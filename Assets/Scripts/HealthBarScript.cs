using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] public Image healthBarImage1;
    [SerializeField] public Image healthBarImage2;
    [SerializeField] public TMP_Text nickNameText1;
    [SerializeField] public TMP_Text nickNameText2;
    //[SerializeField] GameObject player;
    PlayerCombat playerCombat1;

    public Image[] grenadeImages1;
    public Image[] grenadeImages2;

    private void Start()
    {
        
    }
    private void Update()
    {

        HealthBarUpdate();
        grenadeUIUpdate();

    }
    void HealthBarUpdate()
    {
        if(SpawnPlayer.instance.playerList.Count == 2 )
        {
            if(PhotonNetwork.LocalPlayer.ActorNumber ==1)
            {
                healthBarImage1.fillAmount = SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().maxHealth;
                healthBarImage2.fillAmount = SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().maxHealth;
                nickNameText1.text = SpawnPlayer.instance.playerList[0].GetPhotonView().Owner.NickName;
                nickNameText2.text = SpawnPlayer.instance.playerList[1].GetPhotonView().Owner.NickName;
                
            }
            if(PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                healthBarImage1.fillAmount = SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().maxHealth;
                healthBarImage2.fillAmount = SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().currentHealth / SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().maxHealth;
                nickNameText1.text = SpawnPlayer.instance.playerList[1].GetPhotonView().Owner.NickName;
                nickNameText2.text = SpawnPlayer.instance.playerList[0].GetPhotonView().Owner.NickName;
            }
            
        }

    }
    void grenadeUIUpdate()
    {
        if (SpawnPlayer.instance.playerList.Count == 2)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                if (SpawnPlayer.instance.playerList[0].GetComponent<GrenadeThrower>().numberOfGrenades < 1)
                {
                    Destroy(grenadeImages1[0]);
                }
                else if (SpawnPlayer.instance.playerList[0].GetComponent<GrenadeThrower>().numberOfGrenades < 2)
                {
                    Destroy(grenadeImages1[1]);
                }
                else if (SpawnPlayer.instance.playerList[0].GetComponent<GrenadeThrower>().numberOfGrenades < 3)
                {
                    Destroy(grenadeImages1[2]);
                }
                if (SpawnPlayer.instance.playerList[1].GetComponent<GrenadeThrower>().numberOfGrenades < 1)
                {
                    Destroy(grenadeImages2[0]);
                }
                else if (SpawnPlayer.instance.playerList[1].GetComponent<GrenadeThrower>().numberOfGrenades < 2)
                {
                    Destroy(grenadeImages2[1]);
                }
                else if (SpawnPlayer.instance.playerList[1].GetComponent<GrenadeThrower>().numberOfGrenades < 3)
                {
                    Destroy(grenadeImages2[2]);
                }

            }

            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                if (SpawnPlayer.instance.playerList[0].GetComponent<GrenadeThrower>().numberOfGrenades < 1)
                {
                    Destroy(grenadeImages2[0]);
                }
                else if (SpawnPlayer.instance.playerList[0].GetComponent<GrenadeThrower>().numberOfGrenades < 2)
                {
                    Destroy(grenadeImages2[1]);
                }
                else if (SpawnPlayer.instance.playerList[0].GetComponent<GrenadeThrower>().numberOfGrenades < 3)
                {
                    Destroy(grenadeImages2[2]);
                }
                if (SpawnPlayer.instance.playerList[1].GetComponent<GrenadeThrower>().numberOfGrenades < 1)
                {
                    Destroy(grenadeImages1[0]);
                }
                else if (SpawnPlayer.instance.playerList[1].GetComponent<GrenadeThrower>().numberOfGrenades < 2)
                {
                    Destroy(grenadeImages1[1]);
                }
                else if (SpawnPlayer.instance.playerList[1].GetComponent<GrenadeThrower>().numberOfGrenades < 3)
                {
                    Destroy(grenadeImages1[2]);
                }


            }
        }
    }




}
