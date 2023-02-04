using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviour
{
    void Awake()  
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}
