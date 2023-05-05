using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterModification;

public class Character : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private CharacterVitalsStatistic _characteristics;    
    [Header("Property")]
    [SerializeField] private List<Weapon> _weapon;
    
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private Animator _anim;

    protected ICharacter _character;   

    [SerializeField] private Transform _posGroundPoint;
    [SerializeField] private Transform _posRightPoint;

    [SerializeField, Range(2, 6)] private float _speedWalk;
    [SerializeField, Range(2, 6)] private float _speedRun;
    [SerializeField, Range(2, 6)] private float _forceJump;    

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;

    private int _numberWeapon;

    private CharacterState _state;
    private CharacterAnimation _animation;
    private CharacterMovement _movement;

    private void Awake()
    {
        AwakeCharacter();
    }

    private void Start()
    {        
        _state = new CharacterState(_posGroundPoint, _posRightPoint);
        _animation = new CharacterAnimation(_anim);
        _movement = new CharacterMovement(_body, _speedWalk, _speedRun, _forceJump);        
    }

    protected virtual void AwakeCharacter()
    {

    }

    protected virtual void StartCharacter()
    {

    }

    private void OnEnable()
    {        
        OnEnableCharacter();
    }

    private void OnDisable()
    {
        OnDisableCharacter();
    }

    protected virtual void OnEnableCharacter()
    {

    }

    protected virtual void OnDisableCharacter()
    {

    }

    public void ContCharacter()
    {
        _animation.PlayAnimation(_movement, _state);
        _movement.Move(_character, _state, _characteristics);
        _state.CheckState(_groundLayer, _wallLayer, _character);        

        ControlWeapon();
    }    

    public void ControlWeapon()
    {
        if (_weapon.Count > 0)
            _weapon[ActiveWeapon(_character.SwitchWeapon(ref _numberWeapon, _weapon.Count - 1))].ControlWeapon(_character);
    }

    private int ActiveWeapon(int number)
    {
        _numberWeapon = number;

        for (int i = 0; i < _weapon.Count; i++)
        {
            if (i == _numberWeapon)
                _weapon[i].gameObject.SetActive(true);
            else
                _weapon[i].gameObject.SetActive(false);
        }

        return _numberWeapon;
    }
}
