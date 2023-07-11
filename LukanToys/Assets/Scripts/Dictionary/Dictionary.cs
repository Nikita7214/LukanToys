using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UI;
using Object = UnityEngine.Object;

public class Dictionary : SelectLanguage
{
    private string targetKey;
    private Dictionary<string, string> _descriptions;
    [SerializeField] private TextMeshProUGUI descriptionText;
    private string _textUwanRussian = "Иван - мальчик, который любит ходить в лес, наслаждаться природой";
    private string _textTanyaRussian = "Подруга Ивана, с которой он провел все свои годы";
    private string _textUwanEnglish = "Ivan is a boy who loves to go to the forest, enjoy nature";
    private string _textTanyaEnglish = "Ivan's girlfriend, with whom he spent all his years";

    public void LanguageDescription()
    {
        if (dropdown.value == 0)
        {
            _descriptions = new Dictionary<string, string>();
            _descriptions.Add("Иван", _textUwanRussian);
            _descriptions.Add("Таня", _textTanyaRussian);
        }
        else
        {
            _descriptions = new Dictionary<string, string>();
            _descriptions.Add("Uwan", _textUwanEnglish);
            _descriptions.Add("Tanya", _textTanyaEnglish);
        }
    }

    public void ReadInput(string query)
    {
        targetKey = query;
        foreach (var key in _descriptions.Keys)
        {
            if (query == key)
            {
                descriptionText.text = _descriptions[key];
                return;
            }

            descriptionText.text = "";
        }
    }

}
