using Game.Scripts.Character;
using JetBrains.Annotations;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Input
{
    public class InputManager : NetworkBehaviour
    {
        private void Start()
        {
            Debug.Log("Initialized Input Manager");
        }

        // Called with SendMessage
        [UsedImplicitly]
        public void OnMove(InputValue value)
        {
            if (!isLocalPlayer)
            {
                return;
            }

            var moveDirection = value.Get<Vector2>();
            if (moveDirection.sqrMagnitude == 0)
            {
                return;
            }

            ServerMove(moveDirection);
        }

        private static void MoveCharacter(Vector2 moveDirection)
        {
            var currentCharacter = FindObjectOfType<PlayerManager>().CurrentCharacter;
            if (currentCharacter == null)
            {
                return;
            }

            currentCharacter
                .GetComponent<MoveComponent>()
                .Move(moveDirection);
        }

        [ClientRpc]
        // ReSharper disable once MemberCanBeMadeStatic.Local
        private void ClientMoveCharacter(Vector2 moveDirection)
        {
            MoveCharacter(moveDirection);
        }

        // Called with SendMessage
        [UsedImplicitly]
        public void OnSwitchCharacter(InputValue value)
        {
            ServerSwitchCharacter();
        }

        [Command]
        // ReSharper disable once MemberCanBeMadeStatic.Local
        private void ServerSwitchCharacter()
        {
            FindObjectOfType<PlayerManager>().SwitchToNextCharacter();
        }

        [Command]
        private void ServerMove(Vector2 moveDirection)
        {
            if (isServerOnly) // Assume we never will use this in real game
            {
                MoveCharacter(moveDirection);
            }
            ClientMoveCharacter(moveDirection);
        }
    }
}