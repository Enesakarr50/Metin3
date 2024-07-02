using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerAttack attack;
    public GameObject Camera;
    public InventoryController InvController;
    public GameManager GameManager;
    public GameObject Gm;

    public void IsLocalPlayer()
    {
        attack.enabled = true;
        movement.enabled = true;
        Camera.SetActive(true);
    }
    private void Start()
    {
        Gm = GameObject.FindGameObjectWithTag("Gm");
        InvController = GameObject.FindGameObjectWithTag("Gm").GetComponent<InventoryController>();
        GameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
    }
}
