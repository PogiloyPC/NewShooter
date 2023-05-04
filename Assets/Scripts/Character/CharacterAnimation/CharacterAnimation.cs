using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation
{
    private Animator _anim;    

    public CharacterAnimation(Animator anim)
    {
        _anim = anim;
    }

    public void PlayAnimation(CharacterMovement movemment, CharacterState state)
    {
        if (_anim == null)
            return;

        float x = movemment.Body.velocity.x;
        float y = movemment.Body.velocity.y;        

        if ((x > 0.01f || x < -0.01f) && state.IsGrounded && !state.Run)
            _anim.SetBool("walk", true);        
        else
            _anim.SetBool("walk", false);

        if ((x > 0.01f || x < -0.01f) && state.IsGrounded && state.Run)
            _anim.SetBool("run", true);        
        else
            _anim.SetBool("run", false);

        if (x > 0.01f && !state.IsGrounded && state.IsWalled)
            _anim.SetBool("wallIdle", true);
        else
            _anim.SetBool("wallIdle", false);

        if (y > 0.01f)
        {
            _anim.SetBool("jumpUp", true);
            _anim.SetBool("jumpDown", false);
        }
        else if (y < -0.01)
        {
            _anim.SetBool("jumpUp", false);
            _anim.SetBool("jumpDown", true);
        }
        else
        {
            _anim.SetBool("jumpUp", false);
            _anim.SetBool("jumpDown", false);
        }
    }
}
