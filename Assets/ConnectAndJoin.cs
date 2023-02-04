using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ConnectAndJoin : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomName;
    [SerializeField] TMP_InputField roomtoJoin;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomName.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomtoJoin.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
