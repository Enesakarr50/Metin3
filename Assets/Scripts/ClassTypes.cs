using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class", menuName = "Class")]
public class ClassTypes : ScriptableObject
{
    public string ClassNames;
   // public Sprite CharSprite;
    public AnimatorController AnimatorController;
}
