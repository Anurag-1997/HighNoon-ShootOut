using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnetToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField createRoomName;
    [SerializeField] InputField joinRoomName;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.LoadLevel("RoomScene");

    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomName.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
    }

}
