using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
          PhotonNetwork.Destroy(gameObject);
            PhotonNetwork.LeaveLobby();
            SceneManager.LoadScene(3);
        
        
    }
}
