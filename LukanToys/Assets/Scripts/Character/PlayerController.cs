using UnityEngine;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterEventHandler currentCharacter;

        public void Interact(InteractiveObject interactiveObject)
        {
            currentCharacter.OnInteract(interactiveObject);
        }
    }
}
