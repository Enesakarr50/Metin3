using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterClass characterClass;

    public void SetCharacterClass(CharacterClass chosenClass)
    {
        characterClass = chosenClass;
    }
}