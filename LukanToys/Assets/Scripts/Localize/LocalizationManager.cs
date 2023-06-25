using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Localize
{
    public class LocalizationManager : MonoBehaviour
    {
        [SerializeField] private Text _textToLocalize;
        private string[] _lines;
        private const string TEXT_FILE_EN = "LocalizedText_EN";
        private const string TEXT_FILE_RU = "LocalizedText_RU";

        private void Start()
        {
            int language = PlayerPrefs.GetInt("Language", (int)LanguageType.English);
        
            string fileName = language == (int)LanguageType.Russian ? TEXT_FILE_RU : TEXT_FILE_EN;
            string filePath = Application.streamingAssetsPath + "/" + fileName + ".txt";
        
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                _lines = json.Split('\n');
            }
        
            Debug.Log(_lines[0]);
            _textToLocalize.text = GetLocalizedText(_textToLocalize.name);
        }

        private string GetLocalizedText(string key)
        {
            foreach (string line in _lines)
            {
                string[] entry = line.Split('=');

                if (entry[0].Equals(key))
                {
                    return entry[1].Replace("\\n", "\n");
                }
                Debug.Log(entry[0]);
            }

            return "";
        }
    }
}
