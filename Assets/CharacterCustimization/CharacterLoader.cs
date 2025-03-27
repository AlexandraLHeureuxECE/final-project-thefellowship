using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private PlayerCharacterCustomize playerCharacterCustomize;

    private void Start()
    {
        Debug.Log("Customization loaded successfully.");
        playerCharacterCustomize.Load();
    }
}
