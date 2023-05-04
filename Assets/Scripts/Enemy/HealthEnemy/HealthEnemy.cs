using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : Health
{
    [SerializeField] private Transform _UIenemy;
    [SerializeField] private Text _textInfoUI;    

    public override void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, StartHealth);
        _healthBar.fillAmount = _currentHealth / StartHealth;               
        
        DisplayInfoHit(damage);
        
        if (_currentHealth <= 0)        
            Destroy(gameObject);                    
    }

    private void DisplayInfoHit(float damage)
    {
        Text text = Instantiate(_textInfoUI, transform.position, Quaternion.identity);
        text.transform.SetParent(_UIenemy, false);
        text.rectTransform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
        text.text = damage.ToString("0.0");
    }        

    public void OnMouseEnter()
    {
        DisplayHealth(true);
    }

    public void OnMouseExit()
    {
        DisplayHealth(false);
    }
}
