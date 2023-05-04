using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(CharacteristicsCharacter))]
public class DisplayCharacteristics : MonoBehaviour
{    
    [SerializeField] private CharacteristicsCharacter _characteristics;

    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _staminaBar;
    [SerializeField] private Image _energyBar;

    [SerializeField] private Text _healthValue;
    [SerializeField] private Text _staminaValue;
    [SerializeField] private Text _energyValue;

    private void Start()
    {
        _characteristics._displayHealth.AddListener(DisplayHealth);
        _characteristics._displayStamina.AddListener(DisplayStamina);
        _characteristics._displayEnergy.AddListener(DisplayEnergy);        

        _healthValue.text = _characteristics.HealthCharacteristic.ToString("0.0");
        _staminaValue.text = _characteristics.StaminaCharacteristic.ToString("0.0");
        _energyValue.text = _characteristics.EnergyCharacteristic.ToString("0.0");
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
        _characteristics._displayHealth.RemoveListener(DisplayHealth);
        _characteristics._displayStamina.RemoveListener(DisplayStamina);
        _characteristics._displayEnergy.RemoveListener(DisplayEnergy);
    }
}
