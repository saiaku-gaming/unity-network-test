using System.Collections.Generic;
using Game.Scripts.Character;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public class PlayerManager : NetworkBehaviour
    {
        [SerializeField] public GameObject characterPrefab;
        private readonly List<GameObject> _characters = new List<GameObject>();
        private int _currentCharacterIndex;

        private void Start()
        {
            // if (!isServer)
            // {
            //     return;
            // }
            
            NetworkClient.RegisterPrefab(characterPrefab);
            foreach (var spawnPoint in GameObject.FindGameObjectsWithTag("Respawn"))
            {
                Debug.Log(spawnPoint.transform.position);
                var character = Instantiate(characterPrefab, spawnPoint.transform);
                NetworkServer.Spawn(character);
                _characters.Add(character);
                Deselect(character);
            }
            ClientSwitchCharacter(0);
        }

        public GameObject CurrentCharacter => _characters[_currentCharacterIndex];

        public void SwitchToNextCharacter()
        {
            var next = (_currentCharacterIndex + 1) % _characters.Count;
            ClientSwitchCharacter(next);
        }

        [ClientRpc]
        private void ClientSwitchCharacter(int characterIndex)
        {
            Deselect(CurrentCharacter);
            _currentCharacterIndex = characterIndex;
            Select(CurrentCharacter);
        }


        private static void Select(GameObject character)
        {
            character.GetComponent<AppearanceComponent>().Selected();
        }

        private static void Deselect(GameObject character)
        {
            character.GetComponent<AppearanceComponent>().Deselected();
        }
    }
}