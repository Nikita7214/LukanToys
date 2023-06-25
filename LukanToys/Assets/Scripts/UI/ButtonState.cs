using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
  [SerializeField] private Button _nextButton;

  public void OnNextButton()
  {
    if (!_nextButton) return;

    SceneManager.LoadSceneAsync(1);
  }
}
