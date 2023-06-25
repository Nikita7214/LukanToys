using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSettings : MonoBehaviour
{
   [SerializeField] private Button _settingsButton;

   public void OnSettingsButton()
   {
      if (!_settingsButton) return;

      SceneManager.LoadSceneAsync(2);
   }
}
