using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPun
{
    public PlayerMovement movement;
    public PlayerAttack attack;
    public GameObject Camera;
    public GameObject Gm;
    public Animator Anim;

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
        Anim.enabled = true;

        Gm = GameObject.FindGameObjectWithTag("Gm");
        if (Gm != null)
        {
            Anim = movement.animator;
            Gm.GetComponent<GameManager>().enabled = true;
            Gm.GetComponent<InventoryController>().enabled = true;
        }
    }

    private void DisableRemotePlayerComponents()
    {
        attack.enabled = false;
        movement.enabled = false;
        Camera.SetActive(false);
    }
}
