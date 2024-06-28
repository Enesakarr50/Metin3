using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject magePrefab;
    public GameObject knightPrefab;
    public GameObject hunterPrefab;

    void Start()
    {
        CharacterClass chosenClass = (CharacterClass)PlayerPrefs.GetInt("CharacterClass");

        GameObject player = null;
        switch (chosenClass)
        {
            case CharacterClass.Mage:
                player = Instantiate(magePrefab, Vector3.zero, Quaternion.identity);
                break;
            case CharacterClass.Knight:
                player = Instantiate(knightPrefab, Vector3.zero, Quaternion.identity);
                break;
            case CharacterClass.Hunter:
                player = Instantiate(hunterPrefab, Vector3.zero, Quaternion.identity);
                break;
        }

        // Player scriptini oyuncu objesine ekle
        player.GetComponent<Player>().SetCharacterClass(chosenClass);
    }
}