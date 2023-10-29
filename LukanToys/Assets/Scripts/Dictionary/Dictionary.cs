using System.Collections.Generic;
using Dictionary.InterfacesDictionary;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dictionary
{
    public class Dictionary : MonoBehaviour, IDescription
    {
        [SerializeField] private SettingsButtonState _settingsButtonState;
        [SerializeField] private AudioSourceDictionary _audioSourceDictionary;
        [SerializeField] private TextDictionary _textDictionary;
        [SerializeField] private TextPanel _textPanel;
        [SerializeField] private GameSettings _settingsPanel;

        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private DropDownData DropDown;
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _backSettingsButton;
        [SerializeField] private Button _buttonUIPanel;
        
        private string _targetKey;
        private Dictionary<string, string> _descriptions;
        private Dictionary<string, AudioSource> _descriptionAudioSources;

        private void Start()
        {
            _settingsButtonState.panelDictionary.SetActive(false);
            DropDown.dropdown.value = PlayerPrefs.GetInt("DropDownValue", 0);
            _panel.SetActive(true);
        }

        private void Update()
        {
            LanguageAndAudioDescription();
        }
        
        public void LanguageAndAudioDescription()
        {
            if (DropDown.dropdown.value == 0)
            {
                _descriptions = new Dictionary<string, string>();
                _descriptions.Add("Иван", _textDictionary.ivanRussian);
                _descriptions.Add("Таня", _textDictionary.tanyaRussian);
                _descriptions.Add("Лес", _textDictionary.forestRussian);
                _descriptions.Add("Олень", _textDictionary.deerRussian);

                _descriptionAudioSources = new Dictionary<string, AudioSource>();
                _descriptionAudioSources.Add("Иван", _audioSourceDictionary.ivanRussian);
                _descriptionAudioSources.Add("Таня", _audioSourceDictionary.tanyaRussian);
                _descriptionAudioSources.Add("Лес", _audioSourceDictionary.forestRussian);
                _descriptionAudioSources.Add("Олень", _audioSourceDictionary.deerRussian);

                _textPanel.uiPanelRussian.enabled = true;
                _textPanel.backPanelRussian.enabled = true;
                _textPanel.uiPanelEnglish.enabled = false;
                _textPanel.backPanelEnglish.enabled = false;
            }
            else
            {
                _descriptions = new Dictionary<string, string>();
                _descriptions.Add("Ivan", _textDictionary.ivanEnglish);
                _descriptions.Add("Tanya", _textDictionary.tanyaEnglish);
                _descriptions.Add("Forest", _textDictionary.forestEnglish);
                _descriptions.Add("Deer", _textDictionary.deerEnglish);

                _descriptionAudioSources = new Dictionary<string, AudioSource>();
                _descriptionAudioSources.Add("Ivan", _audioSourceDictionary.ivanEnglish);
                _descriptionAudioSources.Add("Tanya", _audioSourceDictionary.tanyaEnglish);
                _descriptionAudioSources.Add("Forest", _audioSourceDictionary.forestEnglish);
                _descriptionAudioSources.Add("Deer", _audioSourceDictionary.deerEnglish);

                _textPanel.uiPanelEnglish.enabled = true;
                _textPanel.uiPanelRussian.enabled = false;
                _textPanel.backPanelEnglish.enabled = true;
                _textPanel.backPanelRussian.enabled = false;
            }
        }

        
        public void ReadInput(string query)
        {
            _targetKey = query;
            foreach (string key in _descriptions.Keys)
            {
                if (query == key)
                {
                    descriptionText.text = _descriptions[key];
                    return;
                }

                descriptionText.text = "";
            }
        }

        public void ClickButtonPanel()
        {
            if (!_buttonUIPanel) return;
            
            _panel.SetActive(false);
        }

        public void BackSettingsButton()
        {
            if (!_backSettingsButton) return;
            
            _settingsPanel.panelSettings.SetActive(true);
            _settingsButtonState.panelDictionary.SetActive(false);
        }
        
        public void OnValueChanged(Dropdown dropdown)
        {
            int value = dropdown.value;
            
            PlayerPrefs.SetInt("DropDownValue", value);
        }
    }
}
