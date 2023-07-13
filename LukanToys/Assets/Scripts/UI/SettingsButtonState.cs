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
        [SerializeField] private Button _supportButton;
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

            SceneManager.LoadSceneAsync(3);
        }
    }
}
