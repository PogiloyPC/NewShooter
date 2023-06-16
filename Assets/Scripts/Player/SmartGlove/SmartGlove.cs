using System.Collections.Generic;
using UnityEngine;
using StateGlove;
using InterfaceModification;

public class SmartGlove : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private List<StateSmartGlove> _statesGlove;

    [SerializeField] private Transform _rayOutHand;

    [SerializeField] private StateGloveType _stateGlove;   

    private IViewStateGlove _viewStateGlove;

    private int _numberStateGlove;

    private void Start()
    {              
        foreach (StateSmartGlove stateGlove in _statesGlove)
            stateGlove.Start();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))        
            ChangeStateGlove(1);        
        else if (Input.GetKeyDown(KeyCode.Q))        
            ChangeStateGlove(-1);        

        ActiveStateGlove(_numberStateGlove);
    }

    private void ChangeStateGlove(int value)
    {
        _numberStateGlove = Mathf.Clamp(_numberStateGlove + value, _statesGlove.Count - _statesGlove.Count, _statesGlove.Count - 1);

        _viewStateGlove.ChangeImageStateGlove(_statesGlove[_numberStateGlove].Image);                    
    }

    private StateGloveType ActiveStateGlove(int numberState)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotateZ = Mathf.Atan2(mousePos.y * _player.localScale.x, mousePos.x * _player.localScale.x) * Mathf.Rad2Deg;

        if (rotateZ <= 75f && rotateZ >= -75f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

            _statesGlove[numberState].ManageState(_rayOutHand.position, mousePos);

            _stateGlove = _statesGlove[numberState].StateGlove;
        }

        return _stateGlove;
    }
    
    public void AddListen(IViewStateGlove viewStateGlove)
    {
        _viewStateGlove = viewStateGlove;

        _viewStateGlove.ChangeImageStateGlove(_statesGlove[_numberStateGlove].Image);
    }
}