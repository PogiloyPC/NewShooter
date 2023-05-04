using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterModification.EnemyModification;

public class EnemyCharacter : Character
{
    [SerializeField, Range(0f, 4f)] private float _rangePatrol;

    [SerializeField] private Transform _direction;

    private EnemyMovable _movableEnemy;

    private void Awake()
    {
        _movableEnemy = new EnemyMovable(_direction, _rangePatrol);
        _character = _movableEnemy;
    }

    private void Update()
    {
       
    }
}
