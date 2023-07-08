using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class Dictionary : MonoBehaviour
{
    private string targetKey;
    private InputField inputField;
    private Dictionary<string, string> descriptions;
    [SerializeField] private TextMeshProUGUI descriptionText;
    private AudioSource targetSource;

    private void Start()
    {
        descriptions = new Dictionary<string, string>();
        descriptions.Add("Иван", "Иван это мальчик который любит ходить в лес, наслаждаться природой");
        descriptions.Add("Таня", "Подруга Ивана, с которой он провел все свои годы");
    }

    public void ReadInput(string query)
    {
        targetKey = query;
        foreach (string key in descriptions.Keys)
        {
            if (query == key)
            {
                descriptionText.text = descriptions[key];
                return;
            }

            descriptionText.text = "";
        }
    }
    
}
