using System;
using System.Diagnostics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Management;

namespace UI
{
    public class SettingsButtonState : MonoBehaviour
    {
        public GameObject panelDictionary;
        [SerializeField] private GameSettings _settings;
        [SerializeField] private Button _supportButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _vkButton;
        [SerializeField] private Button _dictionaryButton;

        public void OpenGmail()
        {
            if (!_supportButton) return;

            Application.OpenURL("mailto:nikitaboklag0@gmail.com");
        }

        public void OpenTelegram()
        {
            if (!_vkButton) return;

            Application.OpenURL("https://t.me/nnnnn513");
        }

        public void OpenDictionary()
        {
            if (!_dictionaryButton) return;

            panelDictionary.SetActive(true);
            _settings.panelSettings.SetActive(false);
        }
        
        public void GoBackGame()
        {
            if (!_backButton) return;

            _settings.panelSettings.SetActive(false);
            _settings.panelUI.SetActive(true);
            _settings.settingsButton.gameObject.SetActive(true);
        }
        
    }
}
