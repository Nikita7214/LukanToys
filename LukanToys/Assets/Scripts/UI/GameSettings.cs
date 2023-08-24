using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace UI
{
   public class GameSettings : MonoBehaviour
   {
      public GameObject panelUI;
      public GameObject panelSettings;
      public Button settingsButton;

      private void Start()
      {
         panelSettings.SetActive(false);
      }

      public void OnSettingsButton()
      {
         if (!settingsButton) return;
      
         panelSettings.SetActive(true);
         panelUI.SetActive(false);
         settingsButton.gameObject.SetActive(false);
      }
   }
}
