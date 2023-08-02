using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
   public class GameSettings : MonoBehaviour
   {
      [SerializeField] private Button _settingsButton;
      private string _targetKey;

      public void OnSettingsButton()
      {
         if (!_settingsButton) return;
      
         SceneManager.LoadSceneAsync(2);
      }
   }
}
