using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustimizationUI : MonoBehaviour
{
   [SerializeField] private Button HairButton;
   [SerializeField] private Button BeardButton;
   [SerializeField] private Button SaveButton;
   [SerializeField] private Button LoadButton;
   
   [SerializeField] private  PlayerCharacterCustomize playerCharacterCustomize;



   private void Awake()
   {
      HairButton.onClick.AddListener(() =>
      {
         Debug.Log("Hair Button Clicked");
         playerCharacterCustomize.ChangeBodyPart(PlayerCharacterCustomize.BodyPartType.Hair);
      });

      BeardButton.onClick.AddListener(() =>
      {
         Debug.Log("Beard Button Clicked");
         playerCharacterCustomize.ChangeBodyPart(PlayerCharacterCustomize.BodyPartType.Beard);
      });
      SaveButton.onClick.AddListener(() =>
      {
         Debug.Log("Save Button Clicked");
         playerCharacterCustomize.Save();
         // Optional: Load next scene here
          //SceneManager.LoadScene(3);
      });
      LoadButton.onClick.AddListener(() =>
      {
         Debug.Log("Load Button Clicked");
         playerCharacterCustomize.Load();
      });

   }
}
