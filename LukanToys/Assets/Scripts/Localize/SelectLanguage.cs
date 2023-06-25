using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectLanguage : MonoBehaviour
    {
        [SerializeField] private Dropdown _dropdown;
        [SerializeField] private Text _russianLangauge;
        [SerializeField] private Text _englishLangauge;
        [SerializeField] private Text _khantyLangauge;
        [SerializeField] private Text _mansiLangauge;
        
        private void Start()
        {
            _dropdown.value = PlayerPrefs.GetInt("DropDownValue", 0);
        }
        
        private void Update()
        {
            SelectDropdown();
        }

        private void SelectDropdown()
        {
            switch (_dropdown.value)
            {
                case 0:
                    _russianLangauge.enabled = true;
                    _englishLangauge.enabled = false;
                    _khantyLangauge.enabled = false;
                    _mansiLangauge.enabled = false;
                    break;
                case 1:
                    _russianLangauge.enabled = false;
                    _englishLangauge.enabled = true;
                    _khantyLangauge.enabled = false;
                    _mansiLangauge.enabled = false;
                    break;
                case 2:
                    _russianLangauge.enabled = false;
                    _englishLangauge.enabled = false;
                    _khantyLangauge.enabled = true;
                    _mansiLangauge.enabled = false;
                    break;
                case 3:
                    _russianLangauge.enabled = false;
                    _englishLangauge.enabled = false;
                    _khantyLangauge.enabled = false;
                    _mansiLangauge.enabled = true;
                    break;
            }
        }

        public void OnValueChanged(Dropdown dropdown)
        {
            int value = dropdown.value;
            
            PlayerPrefs.SetInt("DropDownValue", value);
        }
    }
}
