using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Character
{
    public class ShowTextOnTargetReach : MonoBehaviour
    { 
        public float detectionRadius = 3f; 
        [SerializeField] private GameObject[] _targets;
        [SerializeField] private string[] _targetTexts; 
        [SerializeField] private Text _uiText;

        private void Start()
        {
            _uiText = (Text)GameObject.FindGameObjectWithTag("TextUI").GetComponent(typeof(Text));
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
        }
    }
}
