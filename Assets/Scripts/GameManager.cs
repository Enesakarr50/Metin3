using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ClassTypes Mage;
    public ClassTypes Knight;
    public ClassTypes Hunter;
    public ClassTypes CurrentClass;

    private void Start()
    {
        Class chosenClass = (Class)PlayerPrefs.GetInt("ClassEum");
        CurrentClass = null;

        switch (chosenClass)
        {
            case Class.Mage:
                CurrentClass = Mage;
                PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
                break;
            case Class.Knight:
                CurrentClass = Knight;
                PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
                break;
            case Class.Hunter:
                CurrentClass = Hunter;
                PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
                break;
        }
    }
}
