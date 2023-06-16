using UnityEngine;
using UnityEngine.Events;
using CharacterModification;

public class CharacterVitalsStatistic : MonoBehaviour, ICharacteristicHealth, ICharacteristicStamina, ICharacteristicEnergy
{
    [HideInInspector] public UnityEvent<float, float> OnDisplayHealth;
    [HideInInspector] public UnityEvent<float, float> OnDisplayStamina;
    [HideInInspector] public UnityEvent<float, float> OnDisplayEnergy;
    [HideInInspector] public UnityEvent OnEnabledVitalStatics;

    [SerializeField] private CharacteristicsCharacter _characteristics;    

    private float _currentHealth;
    private float _currentStamina;
    private float _currentEnergy;

    private void Awake()
    {
        _currentHealth = _characteristics.HealthCharacteristic;
        _currentStamina = _characteristics.StaminaCharacteristic;
        _currentEnergy = _characteristics.EnergyCharacteristic;
    }

    private void Start()
    {
        OnDisplayHealth?.Invoke(_currentHealth, _characteristics.HealthCharacteristic);
        OnDisplayStamina?.Invoke(_currentStamina, _characteristics.StaminaCharacteristic);
        OnDisplayEnergy?.Invoke(_currentEnergy, _characteristics.EnergyCharacteristic);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0f)
            damage *= -1f;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, 2000f);

        OnDisplayHealth?.Invoke(_currentHealth, _characteristics.HealthCharacteristic);
        OnEnabledVitalStatics?.Invoke();

        if (_currentHealth <= 0f)
            Destroy(gameObject);
    }

    public void ReduceStamina(float valueStamina)
    {
        if (valueStamina < 0f)
            valueStamina *= -1f;

        _currentStamina = Mathf.Clamp(_currentStamina - valueStamina, 0f, 2000f);

        OnDisplayStamina?.Invoke(_currentStamina, _characteristics.StaminaCharacteristic);
        OnEnabledVitalStatics?.Invoke();
    }

    public void ReduceEnergy(float valueEnergy)
    {
        if (valueEnergy < 0f)
            valueEnergy *= -1f;

        _currentEnergy = Mathf.Clamp(_currentEnergy - valueEnergy, 0f, 2000f);

        OnDisplayEnergy?.Invoke(_currentEnergy, _characteristics.EnergyCharacteristic);
        OnEnabledVitalStatics?.Invoke();
    }

    public void RestoreHealth(float valueHealth)
    {
        if (valueHealth < 0f)
            valueHealth *= -1f;

        _currentHealth = Mathf.Clamp(_currentHealth + valueHealth, 0f, 2000f);

        OnDisplayHealth?.Invoke(_currentHealth, _characteristics.HealthCharacteristic);
    }

    public void RestoreStamina(float valueStamina)
    {
        if (valueStamina < 0f)
            valueStamina *= -1f;

        _currentStamina = Mathf.Clamp(_currentStamina + valueStamina, 0f, 2000f);

        OnDisplayStamina?.Invoke(_currentStamina, _characteristics.StaminaCharacteristic);
    }

    public void RestoreEnergy(float valueEnergy)
    {
        if (valueEnergy < 0f)
            valueEnergy *= -1f;

        _currentEnergy = Mathf.Clamp(_currentEnergy + valueEnergy, 0f, 2000f);

        OnDisplayEnergy?.Invoke(_currentEnergy, _characteristics.EnergyCharacteristic);
    }
}
