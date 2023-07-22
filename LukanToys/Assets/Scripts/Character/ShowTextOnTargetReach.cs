using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class ShowTextOnTargetReach : MonoBehaviour
    {
        public string[] targetTexts; // Массив для хранения текста для каждой цели
        public Text uiText;
        public float detectionRadius = 3f; // Радиус обнаружения целей
        public GameObject[] targets; // Массив объектов целей

        private void Update()
        {
            int currentTargetIndex = -1;
            float closestDistance = Mathf.Infinity;
            for (int i = 0; i < targets.Length; i++)
            {
                Vector3 direction = targets[i].transform.position - transform.position;
                float distanceToTarget = direction.magnitude;

                if (distanceToTarget < detectionRadius && distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    currentTargetIndex = i;
                }
            }

            if (currentTargetIndex != -1)
            {
                string targetText = targetTexts[currentTargetIndex];
                uiText.text = targetText;
            }
            else
            {
                uiText.text = "";
            }
        }

    }
}
