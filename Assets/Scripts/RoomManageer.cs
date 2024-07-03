using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to lobby");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", new Photon.Realtime.RoomOptions(), Photon.Realtime.TypedLobby.Default);
        Debug.Log("We're in the lobby");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameObject _player = PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
        _player.GetComponent<PlayerMovement>().LStart();
    }
}
