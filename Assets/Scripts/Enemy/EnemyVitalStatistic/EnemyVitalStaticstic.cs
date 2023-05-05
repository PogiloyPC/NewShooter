using UnityEngine;
using UnityEngine.UI;

public class EnemyVitalStaticstic : CharacterVitalsStatistic
{
    [SerializeField] private Transform _UIenemy;
    [SerializeField] private Text _textInfoUI;       

    private void DisplayInfoHit(float damage)
    {
        Text text = Instantiate(_textInfoUI, transform.position, Quaternion.identity);
        text.transform.SetParent(_UIenemy, false);
        text.rectTransform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
        text.text = damage.ToString("0.0");
    }          
}
