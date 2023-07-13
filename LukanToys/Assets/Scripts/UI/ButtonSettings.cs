using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ButtonSettings : MonoBehaviour
{
   [SerializeField] private Button _settingsButton;

   public void OnSettingsButton()
   {
      if (!_settingsButton) return;
      
      SceneManager.LoadSceneAsync(2);
   }
}
