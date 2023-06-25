using System;
using UnityEngine;

namespace Script
{
    public class CharacterEventHandler : MonoBehaviour
    {
        public event Action<InteractiveObject> OnInteracted;

        public void OnInteract(InteractiveObject interactiveObject)
        {
            OnInteracted?.Invoke(interactiveObject);
        }
    }
}