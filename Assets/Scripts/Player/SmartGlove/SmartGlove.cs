using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateGlove;

public class SmartGlove : MonoBehaviour
{
    [SerializeField] private List<StateSmartGlove> _statesGlove;

    [SerializeField] private Transform rayOutHand;

    [SerializeField] public StateGloveType stateGlove;

    private int numberStateGlove;

    private void Start()
    {
    }

    private void Update()
    {
        ActiveStateGlove(ChangeStateGlove());
    }

    private int ChangeStateGlove()
    {
        if (Input.GetKeyDown(KeyCode.E))
            numberStateGlove = Mathf.Clamp(numberStateGlove + 1, _statesGlove.Count - _statesGlove.Count, _statesGlove.Count - 1);
        else if (Input.GetKeyDown(KeyCode.Q))
            numberStateGlove = Mathf.Clamp(numberStateGlove - 1, _statesGlove.Count - _statesGlove.Count, _statesGlove.Count - 1);       

        return numberStateGlove;
    }

    private StateGloveType ActiveStateGlove(int numberState)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotateZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (rotateZ <= 75f && rotateZ >= -75f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

            _statesGlove[numberState].ManageState(mousePos);

            stateGlove = _statesGlove[numberState].StateGlove;
        }

        return stateGlove;
    }
}