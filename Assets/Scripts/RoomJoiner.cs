using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomJoiner : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField createRoomName;
    [SerializeField] TMP_InputField joinRoomName;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomName.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
        
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Level 1");
        
    }

}
