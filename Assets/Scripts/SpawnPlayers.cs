using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviour
{   
    void Awake()
    {
        PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
    }
}
