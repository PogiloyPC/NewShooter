using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterModification;

public class CharacterMovement
{
    public Rigidbody2D Body { get; private set; }

    private UnityEvent<float> _changeStamina;

    private float _speedWalk;
    private float _speedRun;
    private float _forceJump;
    private float _reduceStaminaRun = 10f;
    private float _reduceStaminaJump = 100f;


    public CharacterMovement(Rigidbody2D body, float speedWalk, float speedRun, float forceJump)
    {
        Body = body;

        _forceJump = forceJump;
        _speedWalk = speedWalk;
        _speedRun = speedRun;
    }

    public void Move(ICharacter move, CharacterState state, ICharacteristicStamina characteristic)
    {
        if (state.Walk)
        {
            Body.velocity = new Vector2(move.Movement().x * _speedWalk, Body.velocity.y);
        }

        if (state.IsGrounded && state.Run)
        {
            Body.velocity = new Vector2(move.Movement().x * _speedRun, Body.velocity.y);
            characteristic.ReduceStamina(_reduceStaminaRun);            
        }

        if (state.IsGrounded && state.Jump)
        {
            Body.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
            characteristic.ReduceStamina(_reduceStaminaJump);
        }

        if (!state.isReduceStamina && state.IsGrounded)
            characteristic.RestoreStamina(3f);
    }
}