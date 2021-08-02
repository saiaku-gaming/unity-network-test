using Character;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        // Called with SendMessage
        [UsedImplicitly]
        public void OnMove(InputValue value)
        {
            var currentCharacter = GetComponent<PlayerManager>().CurrentCharacter;
            if (currentCharacter == null)
            {
                return;
            }

            currentCharacter
                .GetComponent<MoveComponent>()
                .Move(value.Get<Vector2>());
        }

        // Called with SendMessage
        [UsedImplicitly]
        public void OnSwitchCharacter(InputValue value)
        {
            GetComponent<PlayerManager>()
                .SwitchToNextCharacter();
        }
    }
}