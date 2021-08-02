using Character;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject[] _characters;
    private int _currentCharacterIndex;

    private void Start()
    {
        _characters = GameObject.FindGameObjectsWithTag("Player");
        if (_characters.Length < 1)
        {
            return;
        }

        foreach (var character in _characters)
        {
            Deselect(character);
        }

        Select(_characters[0]);
    }

    [CanBeNull]
    public GameObject CurrentCharacter => _characters.Length > 0 ? _characters[_currentCharacterIndex] : null;

    public void SwitchToNextCharacter()
    {
        Deselect(CurrentCharacter);
        _currentCharacterIndex = (_currentCharacterIndex + 1) % _characters.Length;
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