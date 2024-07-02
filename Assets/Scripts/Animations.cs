using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animations : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
       GetComponent<Animator>().runtimeAnimatorController = gameManager.CurrentClass.AnimatorController ;
    }

}
