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
    [SerializeField] private Dictionary<string, AudioSource> audioSources;
    private AudioSource targetSource;

    private void Start()
    {
        audioSources = new Dictionary<string, AudioSource>()
        {
            ["D"] = new AudioSource(),
            ["A"] = new AudioSource()
        };
        descriptions = new Dictionary<string, string>();
        descriptions.Add("Чум","Чум это домик");
        descriptions.Add("Dani","Hit billy and eat banana controller");
        descriptions.Add("ChatGpt","Супер ИИ");
    }

    public void PlayAudio()
    {
        foreach (var key in audioSources.Keys)
        {
            if (targetKey == key)
            {
                if (targetSource != null)
                {
                    targetSource.Stop();
                }
                targetSource = audioSources[key];
                targetSource.Play();
                return;
            }
        }
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
