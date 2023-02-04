using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class GameManager_PUN : MonoBehaviour
{
    [SerializeField] GameObject PlayerPrefab;

    #region Photon Callbacks

    /// &lt;summary&gt;
    /// Called when the local player left the room. We need to load the launcher scene.
    /// &lt;/summary&gt;
    public void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

    #region Public Methods

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #endregion

    #region Private Methods

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            return;
        }
        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("SampleScene");
    }
    #endregion

    #region Photon Callbacks

    public  void OnPlayerEnteredRoom(Player other)
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name,Vector2.zero,Quaternion.identity);
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting

    if (PhotonNetwork.IsMasterClient)
    {
        Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

        LoadArena();
    }


    }

    public  void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects

    if (PhotonNetwork.IsMasterClient)
    {
        Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

        LoadArena();
    }


    }
    #endregion
}
