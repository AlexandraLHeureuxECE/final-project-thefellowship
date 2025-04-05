using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterCustomize : MonoBehaviour
{
    [SerializeField] private BodyPartData[] bodyPartDataArray;

    private const string PLAYER_PREFS_SAVE = "PlayerCustimization";


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

            SaveObject saveObject = new SaveObject
            {
                bodyPartTypeIndexList = bodyPartTypeIndexList

            };
            string Json = JsonUtility.ToJson(saveObject);
            Debug.Log(Json);
            PlayerPrefs.SetString(PLAYER_PREFS_SAVE, Json);
        }
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
    }
    
    
}



