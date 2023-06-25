using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

            Application.OpenURL("mailto:zk.german@yandex.ru");
        }

        public void OpenVk()
        {
            if (!_vkButton) return;
        
            ProcessStartInfo info = new ProcessStartInfo("https://m.vk.com/lukan_sever_toys?from=groups");
            Process.Start(info);
        }

        public void OpenDictionary()
        {
            if (!_dictionaryButton) return;

            SceneManager.LoadSceneAsync(3);
        }
    }
}
