using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class DisplayVitalStatistics : MonoBehaviour
{
    [SerializeField] private CharacterVitalsStatistic _characteristics;

    [SerializeField] private GameObject _vitalStatistics;

    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _staminaBar;
    [SerializeField] private Image _energyBar;

    [SerializeField] private Text _healthValue;
    [SerializeField] private Text _staminaValue;
    [SerializeField] private Text _energyValue;

    private void Start()
    {
        _characteristics.OnEnabledVitalStatics.AddListener(EnabledVitalStatics);
        _characteristics.OnDisplayHealth.AddListener(DisplayHealth);
        _characteristics.OnDisplayStamina.AddListener(DisplayStamina);
        _characteristics.OnDisplayEnergy.AddListener(DisplayEnergy);        

        Invoke("DisableVital", 3f);
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

    private void EnabledVitalStatics()
    {
        _vitalStatistics.SetActive(true);

        Invoke("DisableVital", 3f);
    }

    private void DisableVital()
    {
        _vitalStatistics.SetActive(false);
    }

    private void OnDestroy()
    {
        _characteristics.OnEnabledVitalStatics.RemoveListener(EnabledVitalStatics);
        _characteristics.OnDisplayHealth.RemoveListener(DisplayHealth);
        _characteristics.OnDisplayStamina.RemoveListener(DisplayStamina);
        _characteristics.OnDisplayEnergy.RemoveListener(DisplayEnergy);
    }
}
