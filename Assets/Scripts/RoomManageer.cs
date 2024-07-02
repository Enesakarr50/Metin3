using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManageer : MonoBehaviourPunCallbacks
{
    
   // Start is called before the first frame update
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
        PhotonNetwork.JoinOrCreateRoom("test", null, null);
        Debug.Log("We're in");
       
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameObject _player = PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<PlayerMovement>().LStart();
        Debug.Log("1");

    }
}
