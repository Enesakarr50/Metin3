using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManageer : MonoBehaviourPunCallbacks
{
    GameObject _player;
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
        _player = PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }
    public override void OnCreatedRoom()

    {
        
        base.OnCreatedRoom();
        
    }
}
