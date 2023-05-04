using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using CharacterModification;

[RequireComponent(typeof(Character))]
public abstract class CharacteristicsCharacter : MonoBehaviour, ICharacteristicHealth, ICharacteristicStamina, ICharacteristicEnergy
{
    [HideInInspector] public UnityEvent<float, float> _displayHealth;
    [HideInInspector] public UnityEvent<float, float> _displayStamina;
    [HideInInspector] public UnityEvent<float, float> _displayEnergy;

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

    public float _startHealth { get; private set; }
    public float _startStamina { get; private set; }
    public float _startEnergy { get; private set; }   

    private void Start()
    {        
        _startHealth = _healthCharacteristic;
        _startStamina = _staminaCharacteristic;
        _startEnergy = _energyCharacteristic;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0f)
            damage *= -1f;

        _healthCharacteristic = Mathf.Clamp(_healthCharacteristic - damage, 0f, 2000f);

        _displayHealth?.Invoke(_healthCharacteristic, _startHealth);
    }

    public void ReduceStamina(float valueStamina)
    {
        if (valueStamina < 0f)
            valueStamina *= -1f;

        _staminaCharacteristic = Mathf.Clamp(_staminaCharacteristic - valueStamina, 0f, 2000f);

        _displayStamina?.Invoke(_staminaCharacteristic, _startStamina);
    }

    public void ReduceEnergy(float valueEnergy)
    {
        if (valueEnergy < 0f)
            valueEnergy *= -1f;

        _energyCharacteristic = Mathf.Clamp(_energyCharacteristic - valueEnergy, 0f, 2000f);

        _displayEnergy?.Invoke(_energyCharacteristic, _startEnergy);
    }

    public void RestoreHealth(float valueHealth)
    {
        if (valueHealth < 0f)
            valueHealth *= -1f;

        _healthCharacteristic = Mathf.Clamp(_healthCharacteristic + valueHealth, 0f, 2000f);

        _displayHealth?.Invoke(_healthCharacteristic, _startHealth);
    }

    public void RestoreStamina(float valueStamina)
    {
        if (valueStamina < 0f)
            valueStamina *= -1f;

        _staminaCharacteristic = Mathf.Clamp(_staminaCharacteristic + valueStamina, 0f, 2000f);

        _displayStamina?.Invoke(_staminaCharacteristic, _startStamina);
    }

    public void RestoreEnergy(float valueEnergy)
    {
        if (valueEnergy < 0f)
            valueEnergy *= -1f;

        _energyCharacteristic = Mathf.Clamp(_energyCharacteristic + valueEnergy, 0f, 2000f);

        _displayEnergy?.Invoke(_energyCharacteristic, _startEnergy);
    }
}
