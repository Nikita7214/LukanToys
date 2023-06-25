using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class InteractiveObject : MonoBehaviour , IPointerClickHandler
    {
        public Transform targetTransform;
        private PlayerController playerController;
        
        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            playerController.Interact(this);
            Debug.Log("Clicked");
        }
    }
}