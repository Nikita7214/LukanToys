using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Script
{
    public class SceneChanger : MonoBehaviour
    {
        public void SetScene(int i)
        {
            SceneManager.LoadScene(i);
        }
    }
}