using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectLanguage : MonoBehaviour
    {
        public DropDownData DropDownData;
        [SerializeField] private Text _russianLangauge;
        [SerializeField] private Text _englishLangauge;

        private void Start()
        {
            DropDownData.dropdown.value = PlayerPrefs.GetInt("DropDownValue", 0);
        }
        
        private void Update()
        {
            SelectDropdown();
        }

        private void SelectDropdown()
        {
            switch (DropDownData.dropdown.value)
            {
                case 0:
                    _russianLangauge.enabled = true;
                    _englishLangauge.enabled = false;
                    break;
                case 1:
                    _englishLangauge.enabled = true;
                    _russianLangauge.enabled = false;
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

[Serializable]
public class DropDownData 
{
    public Dropdown dropdown;
}
