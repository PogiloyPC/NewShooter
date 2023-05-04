using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerFunction;

public class GrapplingHook : StateSmartGlove
{
    [SerializeField] private LineRenderer _ropeLine;

    [SerializeField] private Transform _posShootGrapplingHook;
    [SerializeField] private Transform _targetGrapplingHook;

    [SerializeField] private float _speedGrapplingHook;
    [SerializeField] private float _distanceGrapplingHook;

    private bool _isHooked;

    private Vector2 _directionFly;

    public override void ManageState(Vector2 mousePos)
    {        
    }
}
