using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class GameOverPanelScript : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TMP_Text gameOverText;

    private void Update()
    {
        gameOverScreen();
    }
    void gameOverScreen()
    {
        if (SpawnPlayer.instance.playerList.Count == 2)
        {
            if(PhotonNetwork.LocalPlayer.ActorNumber ==1)
            {
                if (SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().currentHealth <= 0)
                {
                    gameOverCanvas.SetActive(true);
                    gameOverText.text = SpawnPlayer.instance.playerList[1].GetPhotonView().Owner.NickName+"has won";
                }
                if (SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().currentHealth <= 0)
                {
                    gameOverCanvas.SetActive(true);
              
                    gameOverText.text = SpawnPlayer.instance.playerList[0].GetPhotonView().Owner.NickName+"has won";
                }
            }
            if(PhotonNetwork.LocalPlayer.ActorNumber ==2)
            {
                if (SpawnPlayer.instance.playerList[1].GetComponent<PlayerCombat>().currentHealth <= 0)
                {
                    gameOverCanvas.SetActive(true);
                    
                    gameOverText.text = SpawnPlayer.instance.playerList[1].GetPhotonView().Owner.NickName+"has won";
                }
                if (SpawnPlayer.instance.playerList[0].GetComponent<PlayerCombat>().currentHealth <= 0)
                {
                    gameOverCanvas.SetActive(true);
                    gameOverText.text = "Player 1 has won";
                    gameOverText.text = SpawnPlayer.instance.playerList[0].GetPhotonView().Owner.NickName+"has won";
                }
            }
           

        }
    }

}
