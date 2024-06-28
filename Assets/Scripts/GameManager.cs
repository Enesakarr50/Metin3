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
        Classes chosenClass = (Classes)PlayerPrefs.GetInt("ClassEum");
        CurrentClass = null;

        switch (chosenClass)
        {
            case Classes.Mage:
                CurrentClass = Mage;
                break;
            case Classes.Knight:
                CurrentClass = Knight;
                break;
            case Classes.Hunter:
                CurrentClass = Hunter;
                break;
        }
    }
}
