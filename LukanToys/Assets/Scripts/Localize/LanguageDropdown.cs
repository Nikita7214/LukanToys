using UnityEngine;
using UnityEngine.UI;

public enum LanguageType
{
    English,
    Russian,
}

public class LanguageDropdown : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;
    private const string LANGUAGE_KEY = "Language";

    private void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(LANGUAGE_KEY, (int)LanguageType.English);
        
        _dropdown.onValueChanged.AddListener(delegate { OnValueChange(); });
    }

    private void OnValueChange()
    {
        PlayerPrefs.SetInt(LANGUAGE_KEY, _dropdown.value);
    }
}

