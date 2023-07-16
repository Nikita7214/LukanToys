using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dictionary
{
    public class Dictionary : SelectLanguage
    {
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private GameObject _panel;
        [SerializeField] private Text _textUIPanelRussian;
        [SerializeField] private Text _textUIPanelEnglish;
        [SerializeField] private Button _buttonUIPanel;
        private string targetKey;
        private Dictionary<string, string> _descriptions;
        
        private string _textUwanRussian = "Иван - мальчик, который любит ходить в лес, наслаждаться природой";
        private string _textTanyaRussian = "Подруга Ивана, с которой он провел все свои годы";
        private string _textUwanEnglish = "Ivan is a boy who loves to go to the forest, enjoy nature";
        private string _textTanyaEnglish = "Ivan's girlfriend, with whom he spent all his years";

        private void Start()
        {
            dropdown.value = PlayerPrefs.GetInt("DropDownValue", 1);
            _panel.SetActive(true);
        }
        
        public void LanguageDescription()
        {
            if (dropdown.value == 0)
            {
                _descriptions = new Dictionary<string, string>();
                _descriptions.Add("Иван", _textUwanRussian);
                _descriptions.Add("Таня", _textTanyaRussian);
                _textUIPanelRussian.enabled = true;
                _textUIPanelEnglish.enabled = false;
            }
            else
            {
                _descriptions = new Dictionary<string, string>();
                _descriptions.Add("Ivan", _textUwanEnglish);
                _descriptions.Add("Tanya", _textTanyaEnglish);
                _textUIPanelEnglish.enabled = true;
                _textUIPanelRussian.enabled = false;
            }
        }

        public void ReadInput(string query)
        {
            targetKey = query;
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
            {
                _panel.SetActive(false);
            }
        }
    }
}
