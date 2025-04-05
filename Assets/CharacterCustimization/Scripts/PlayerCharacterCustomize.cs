using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCharacterCustomize : MonoBehaviour
{
    [SerializeField] private BodyPartData[] bodyPartDataArray;

    [Header("Weapon Selection")]
    [SerializeField] private GameObject[] availableWeapons;
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI weaponInfoText;
    
    private const string PLAYER_PREFS_SAVE = "PlayerCustimization";

    private int selectedWeaponIndex = 0;
    
    

    public enum BodyPartType
    {
        Hair,
        Beard,
    }

    [System.Serializable] // it will make the class appear in the system
    public class BodyPartData
    {
        public BodyPartType bodyPartType;
        public Mesh[] meshArray;
        public SkinnedMeshRenderer SkinnedMeshRenderer;
    }


    public void ChangeBodyPart(BodyPartType bodyPartType)
    {
        BodyPartData bodyPartData = GetBodyPartData(bodyPartType);
        int meshIndex = Array.IndexOf(bodyPartData.meshArray, bodyPartData.SkinnedMeshRenderer.sharedMesh);
        bodyPartData.SkinnedMeshRenderer.sharedMesh = bodyPartData.meshArray[(meshIndex + 1) % bodyPartData.meshArray.Length];
    }

    private BodyPartData GetBodyPartData(BodyPartType bodyPartType)
    {
        //loop through each body part data in the array
        foreach (BodyPartData bodyPartData in bodyPartDataArray)
        {
            //if the body part type matches the input body part type, return the body part data
            if (bodyPartData.bodyPartType == bodyPartType)
            {
                return bodyPartData;
            }
        }

        //if no body part data is found, return null
        return null;
    }

    [Serializable]
    public class BodyPartTypeIndex
    {
        public BodyPartType bodyPartType;
        public int index;
    }

    public class SaveObject
    {
        public List<BodyPartTypeIndex> bodyPartTypeIndexList;
        public int weaponIndex;
    }

    public void Save()
    {
        List<BodyPartTypeIndex> bodyPartTypeIndexList = new List<BodyPartTypeIndex>();

        foreach (BodyPartType bodyPartType in Enum.GetValues(typeof(BodyPartType)))
        {
            BodyPartData bodyPartData = GetBodyPartData(bodyPartType);
            int meshIndex = Array.IndexOf(bodyPartData.meshArray, bodyPartData.SkinnedMeshRenderer.sharedMesh);

            bodyPartTypeIndexList.Add(new BodyPartTypeIndex
            {
                bodyPartType = bodyPartType,
                index = meshIndex
            });
        }

        SaveObject saveObject = new SaveObject
            {
                bodyPartTypeIndexList = bodyPartTypeIndexList,
                weaponIndex = selectedWeaponIndex
            };
            string Json = JsonUtility.ToJson(saveObject);
            Debug.Log(Json);
            PlayerPrefs.SetString(PLAYER_PREFS_SAVE, Json);
        
    }

    public void Load()
    {
        string json = PlayerPrefs.GetString(PLAYER_PREFS_SAVE);
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(json);
        
        foreach (BodyPartTypeIndex bodyPartTypeIndex in saveObject.bodyPartTypeIndexList)
        {
            BodyPartData bodyPartData = GetBodyPartData(bodyPartTypeIndex.bodyPartType);
            bodyPartData.SkinnedMeshRenderer.sharedMesh = bodyPartData.meshArray[bodyPartTypeIndex.index];
        }
        selectedWeaponIndex = saveObject.weaponIndex;
        EquipSelectedWeapon();
    }
    
    public void SelectNextWeapon()
    {
        selectedWeaponIndex = (selectedWeaponIndex + 1) % availableWeapons.Length;
        EquipSelectedWeapon();
    }
    
    private void EquipSelectedWeapon()
    {
        player.Equip(availableWeapons[selectedWeaponIndex]); //Equips Weapon

        Weapon weaponDesc = availableWeapons[selectedWeaponIndex].GetComponent<Weapon>(); // Updates UI
        
        if (weaponDesc != null && weaponInfoText != null)
        {
            weaponInfoText.text = $"{weaponDesc.weaponName}\n<color=grey>{weaponDesc.weaponDescription}</color>";
            Debug.Log("Equipped weapon: " + weaponDesc.weaponName);
        }
    }
    
}



