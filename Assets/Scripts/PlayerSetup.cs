using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerAttack attack;
    public GameObject Camera;
    public GameObject Gm;

    public void IsLocalPlayer()
    {
        attack.enabled = true;
        movement.enabled = true;
        Camera.SetActive(true);
        Gm = GameObject.FindGameObjectWithTag("Gm");
        Gm.GetComponent<GameManager>().enabled = true;
        Gm.GetComponent<InventoryController>().enabled = true;
    }
}
