using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{    
    [SerializeField] protected Image _healthBar;
    [SerializeField] protected float _currentHealth;
    public float StartHealth { get; private set; }     

    private void Start()
    {
        StartHealth = _currentHealth;
    }

    public abstract void TakeDamage(float damage);

    public void DisplayHealth(bool display)
    {        
        _healthBar.gameObject.SetActive(display);        
    }        
}
