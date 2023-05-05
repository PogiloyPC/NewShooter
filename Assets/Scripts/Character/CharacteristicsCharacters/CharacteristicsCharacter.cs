using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Character))]
public abstract class CharacteristicsCharacter : MonoBehaviour
{   
    [SerializeField, Range(200, 2000)] private float _healthCharacteristic;
    [SerializeField, Range(200, 2000)] private float _staminaCharacteristic;
    [SerializeField, Range(200, 2000)] private float _energyCharacteristic;
    [SerializeField, Range(200, 2000)] private float _agilityCharacteristic;
    [SerializeField, Range(200, 2000)] private float _strengthCharacteristic;
    [SerializeField, Range(200, 2000)] private float _firearmsCharacteristic;
    public float HealthCharacteristic { get { return _healthCharacteristic; } private set { } }
    public float StaminaCharacteristic { get { return _staminaCharacteristic; } private set { } }
    public float EnergyCharacteristic { get { return _energyCharacteristic; } private set { } }
    public float AgilityCharacteristic { get { return _agilityCharacteristic; } private set { } }
    public float StrengthCharacteristic { get { return _strengthCharacteristic; } private set { } }
    public float FirearmsCharacteristic { get { return _firearmsCharacteristic; } private set { } }    
}
