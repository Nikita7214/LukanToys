using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

namespace Character
{
    public class ShowTextOnTargetReach : MonoBehaviour
    {
        public DropDownData Dropdown;
        public float detectionRadius = 3f; 
        [SerializeField] private GameObject[] _targets;
        [SerializeField] private string[] _targetTexts; 
        [SerializeField] private Text _uiText;

        private void Start()
        {
            _uiText = (Text)GameObject.FindGameObjectWithTag("TextUI").GetComponent(typeof(Text));
            Dropdown.dropdown.value = PlayerPrefs.GetInt("DropDownValue", 0);
        }
        
        private void Update()
        {
            int currentTargetIndex = -1;
            float closestDistance = Mathf.Infinity;
            for (int i = 0; i < _targets.Length; i++)
            {
                Vector3 direction = _targets[i].transform.position - transform.position;
                float distanceToTarget = direction.magnitude;

                if (distanceToTarget < detectionRadius && distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    currentTargetIndex = i;
                }
            }

            if (currentTargetIndex != -1)
            {
                string targetText = _targetTexts[currentTargetIndex];
                _uiText.gameObject.SetActive(true);
                _uiText.text = targetText;
            }
            else
            {
                _uiText.text = "";
            }
            
            if (Dropdown.dropdown.value == 1)
            {
                _targetTexts[0] = "The forest is what I love the most!";
                _targetTexts[1] = "Deer are such beautiful animals!";
                _targetTexts[2] = "Tanya is a friend with whom we love to walk in the woods!";
            }
        }
        
        public void OnValueChanged(Dropdown dropdown)
        {
            int value = dropdown.value;
            
            PlayerPrefs.SetInt("DropDownValue", value);
        }
    }
}

