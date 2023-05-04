using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateGlove;

public abstract class StateSmartGlove : Item
{
    [SerializeField] private StateGloveType _stateGlove;    

    public StateGloveType StateGlove { get{ return _stateGlove; } private set { } }

    public abstract void ManageState(Vector2 mousePos);    
}
