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
                break;
            case Class.Knight:
                CurrentClass = Knight;
                break;
            case Class.Hunter:
                CurrentClass = Hunter;
                break;
        }
    }
}
