using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterModification.PlayerModification;

public class CharacterPlayer : Character
{
    private PlayerInput _playerInput;

    protected override void AwakeCharacter()
    {
        _playerInput = new PlayerInput(transform);
        _character = _playerInput;        
    }

    protected override void StartCharacter()
    {
        
    }

    protected virtual void AwakePlayer()
    {

    }

    protected virtual void StartPlayer()
    {

    }
}
