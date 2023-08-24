using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Dictionary
{
    public class Dictionary : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private DropDownData DropDown;
        [SerializeField] private AudioSource _audioDeerRussian;
        [SerializeField] private AudioSource _audioTanyaRussian;
        [SerializeField] private AudioSource _audioUwanRussian;
        [SerializeField] private AudioSource _audioForestRussian;
        [SerializeField] private AudioSource _audioDeerEnglish;
        [SerializeField] private AudioSource _audioTanyaEnglish;
        [SerializeField] private AudioSource _audioUwanEnglish;
        [SerializeField] private AudioSource _audioForestEnglish;
        [SerializeField] private GameObject _panel;
        [SerializeField] private Text _textUIPanelRussian;
        [SerializeField] private Text _textUIPanelEnglish;
        [SerializeField] private Text _textBackPanelRussian;
        [SerializeField] private Text _textBackPanelEnglish;
        [SerializeField] private Button _buttonUIPanel;
        private string _targetKey;
        private Dictionary<string, string> _descriptions;
        private Dictionary<string, AudioSource> _descriptionAudioSources;

        private string _textDeerRussian = "Олень это дикое животное, которое обитает в нашем уютном лесу";
        private string _textDeerEnglish = "Deer is a wild animal that lives in our cozy forest";
        private string _textForestRussian = "Лес это не только красивые деревья,травка или грибы, но и хорошое времяпровождение и отдых там";
        private string _textForestEnglish =
            "The forest is not only beautiful trees, grass or mushrooms, but also a good pastime and relaxation there";
        private string _textUwanRussian = "Иван - мальчик, который любит ходить в лес, наслаждаться природой";
        private string _textTanyaRussian = "Подруга Ивана, с которой он провел все свои годы";
        private string _textUwanEnglish = "Ivan is a boy who loves to go to the forest, enjoy nature";
        private string _textTanyaEnglish = "Ivan's girlfriend, with whom he spent all his years";

        private void Start()
        {
            DropDown.dropdown.value = PlayerPrefs.GetInt("DropDownValue", 0);
            _panel.SetActive(true);
        }
        
        private void Update()
        {
            LanguageDescription();
        }

        private void LanguageDescription()
        {
            if (DropDown.dropdown.value == 0)
            {
                _descriptions = new Dictionary<string, string>();
                _descriptions.Add("Иван", _textUwanRussian);
                _descriptions.Add("Таня", _textTanyaRussian);
                _descriptions.Add("Лес", _textForestRussian);
                _descriptions.Add("Олень", _textDeerRussian);
                _textUIPanelRussian.enabled = true;
                _textBackPanelRussian.enabled = true;
                _textUIPanelEnglish.enabled = false;
                _textBackPanelEnglish.enabled = false;
            }
            else
            {
                _descriptions = new Dictionary<string, string>();
                _descriptions.Add("Ivan", _textUwanEnglish);
                _descriptions.Add("Tanya", _textTanyaEnglish);
                _descriptions.Add("Forest", _textForestEnglish);
                _descriptions.Add("Deer", _textDeerEnglish);
                _textUIPanelEnglish.enabled = true;
                _textUIPanelRussian.enabled = false;
                _textBackPanelEnglish.enabled = true;
                _textBackPanelRussian.enabled = false;
            }
        }

        public void AudioDescription()
        {
            if (DropDown.dropdown.value == 0)
            {
                _descriptionAudioSources = new Dictionary<string, AudioSource>();
                _descriptionAudioSources.Add("Иван", _audioUwanRussian);
                _descriptionAudioSources.Add("Таня", _audioTanyaRussian);
                _descriptionAudioSources.Add("Лес", _audioForestRussian);
                _descriptionAudioSources.Add("Олень", _audioDeerRussian);
            }
            else
            {
                _descriptionAudioSources = new Dictionary<string, AudioSource>();
                _descriptionAudioSources.Add("Иван", _audioUwanEnglish);
                _descriptionAudioSources.Add("Таня", _audioTanyaEnglish);
                _descriptionAudioSources.Add("Лес", _audioForestEnglish);
                _descriptionAudioSources.Add("Олень", _audioDeerEnglish);
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
        
        public void OnValueChanged(Dropdown dropdown)
        {
            int value = dropdown.value;
            
            PlayerPrefs.SetInt("DropDownValue", value);
        }
    }
}
