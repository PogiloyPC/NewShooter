using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(CharacteristicsCharacter))]
public class DisplayCharacteristics : MonoBehaviour
{    
    [SerializeField] private CharacterVitalsStatistic _characteristics;

    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _staminaBar;
    [SerializeField] private Image _energyBar;

    [SerializeField] private Text _healthValue;
    [SerializeField] private Text _staminaValue;
    [SerializeField] private Text _energyValue;

    private void Start()
    {
        _characteristics.OnDisplayHealth.AddListener(DisplayHealth);
        _characteristics.OnDisplayStamina.AddListener(DisplayStamina);
        _characteristics.OnDisplayEnergy.AddListener(DisplayEnergy);        

        _healthValue.text = _characteristics.StartHealth.ToString("0.0");
        _staminaValue.text = _characteristics.StartStamina.ToString("0.0");
        _energyValue.text = _characteristics.StartEnergy.ToString("0.0");
    }

    private void DisplayHealth(float currentHealth, float startHealth)
    {
        _healthBar.fillAmount = currentHealth / startHealth;

        _healthValue.text = currentHealth.ToString("0.0");
    } 
    
    private void DisplayStamina(float currentStamina, float startStamina)
    {
        _staminaBar.fillAmount = currentStamina / startStamina;

        _staminaValue.text = currentStamina.ToString("0.0");
    }
    
    private void DisplayEnergy(float currentEnergy, float startSEnergy)
    {
        _energyBar.fillAmount = currentEnergy / startSEnergy;

        _energyValue.text = currentEnergy.ToString("0.0");
    }

    private void OnDestroy()
    {
        _characteristics.OnDisplayHealth.RemoveListener(DisplayHealth);
        _characteristics.OnDisplayStamina.RemoveListener(DisplayStamina);
        _characteristics.OnDisplayEnergy.RemoveListener(DisplayEnergy);
    }
}
