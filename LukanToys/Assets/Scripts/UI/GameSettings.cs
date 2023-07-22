using System;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GameSettings : MonoBehaviour
{
   [SerializeField] private Button _settingsButton;
   private string _targetKey;

   public void OnSettingsButton()
   {
      if (!_settingsButton) return;
      
      SceneManager.LoadSceneAsync(2);
   }
}
