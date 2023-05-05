using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterModification;

public class CharacterVitalsStatistic : MonoBehaviour, ICharacteristicHealth, ICharacteristicStamina, ICharacteristicEnergy
{
    [HideInInspector] public UnityEvent<float, float> OnDisplayHealth;
    [HideInInspector] public UnityEvent<float, float> OnDisplayStamina;
    [HideInInspector] public UnityEvent<float, float> OnDisplayEnergy;

    [SerializeField] private CharacteristicsCharacter _characteristics;

    public float StartHealth { get; private set; }
    public float StartStamina { get; private set; }
    public float StartEnergy { get; private set; }
    private float _currentHealth;
    private float _currentStamina;
    private float _currentEnergy;

    private void Awake()
    {
        StartHealth = _characteristics.HealthCharacteristic;
        StartStamina = _characteristics.StaminaCharacteristic;
        StartEnergy = _characteristics.EnergyCharacteristic;

        _currentHealth = StartHealth;
        _currentStamina = StartStamina;
        _currentEnergy = StartEnergy;
}

    public void TakeDamage(float damage)
    {
        if (damage < 0f)
            damage *= -1f;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, 2000f);

        OnDisplayHealth?.Invoke(_currentHealth, StartHealth);
    }

    public void ReduceStamina(float valueStamina)
    {
        if (valueStamina < 0f)
            valueStamina *= -1f;

        _currentStamina = Mathf.Clamp(_currentStamina - valueStamina, 0f, 2000f);

        OnDisplayStamina?.Invoke(_currentStamina, StartStamina);
    }

    public void ReduceEnergy(float valueEnergy)
    {
        if (valueEnergy < 0f)
            valueEnergy *= -1f;

        _currentEnergy = Mathf.Clamp(_currentEnergy - valueEnergy, 0f, 2000f);

        OnDisplayEnergy?.Invoke(_currentEnergy, StartEnergy);
    }

    public void RestoreHealth(float valueHealth)
    {
        if (valueHealth < 0f)
            valueHealth *= -1f;

        _currentHealth = Mathf.Clamp(_currentHealth + valueHealth, 0f, 2000f);

        OnDisplayHealth?.Invoke(_currentHealth, StartHealth);
    }

    public void RestoreStamina(float valueStamina)
    {
        if (valueStamina < 0f)
            valueStamina *= -1f;

        _currentStamina = Mathf.Clamp(_currentStamina + valueStamina, 0f, 2000f);

        OnDisplayStamina?.Invoke(_currentStamina, StartStamina);
    }

    public void RestoreEnergy(float valueEnergy)
    {
        if (valueEnergy < 0f)
            valueEnergy *= -1f;

        _currentEnergy = Mathf.Clamp(_currentEnergy + valueEnergy, 0f, 2000f);

        OnDisplayEnergy?.Invoke(_currentEnergy, StartEnergy);
    }
}
