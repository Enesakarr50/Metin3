using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEditor.Animations;

public class PlayerSetup : MonoBehaviourPun
{
    public PlayerMovement movement;
    public PlayerAttack attack;
    public GameObject Camera;
    public GameObject Gm;
    public Animator asd;


    void Start()
    {
        if (photonView.IsMine)
        {
            IsLocalPlayer();
        }
        else
        {
            DisableRemotePlayerComponents();
        }
    }

    public void IsLocalPlayer()
    {
        attack.enabled = true;
        movement.enabled = true;
        Camera.SetActive(true);
        

        Gm = GameObject.FindGameObjectWithTag("Gm");
        
        if (Gm != null)
        {
            
            Gm.GetComponent<GameManager>().enabled = true;
            Gm.GetComponent<InventoryController>().enabled = true;
            asd.runtimeAnimatorController = movement.animator.runtimeAnimatorController;
        }
    }

    private void DisableRemotePlayerComponents()
    {
        attack.enabled = false;
        movement.enabled = false;
        Camera.SetActive(false);
    }
}
