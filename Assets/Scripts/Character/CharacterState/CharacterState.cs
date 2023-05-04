using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterModification;

public class CharacterState
{
    private Transform _checkGroundPos;
    private Transform _checkRightPos;    

    private float _radiusCircleRight = 0.3f;
    private float _radiusCircleGround = 0.3f;

    public bool FaceRight { get; private set; }
    public bool Walk { get; private set; }
    public bool Run { get; private set; }
    public bool Jump { get; private set; }
    public bool isReduceStamina { get; private set; }

    public bool IsGrounded { get; private set; }
    public bool IsWalled { get; private set; }

    public CharacterState(Transform pointGroundCheck, Transform pointRightCheck)
    {
        _checkGroundPos = pointGroundCheck;
        _checkRightPos = pointRightCheck;        
    }

    public void CheckState(LayerMask layerGround, LayerMask layerWall, ICharacter movement)
    {
        Walk = movement.DesireWalk();
        Run = movement.DesireRun();
        Jump = movement.DesireJump();

        isReduceStamina = Run || Jump;

        IsGrounded = Physics2D.OverlapCircle(_checkGroundPos.position, _radiusCircleGround, layerGround);
        IsWalled = Physics2D.OverlapCircle(_checkRightPos.position, _radiusCircleRight, layerWall);
    }    
}
