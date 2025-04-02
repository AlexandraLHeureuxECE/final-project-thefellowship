using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public static CharacterData Instance;

    public int savedHairIndex;
    public int savedBeardIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
