using UnityEngine;
using GunSystem.Bullet;

public class Bullet : MonoBehaviour
{
    [SerializeField] private TypeBullet _typeBullet;
    [SerializeField] private Rigidbody2D _rb;     

    [SerializeField] private float _lifeBullet;
    private float _speed;
    private float _damage;

    [SerializeField, Range(1, 10)] private int _breakingCapacity;
    private int _touch;

    private void Start()
    {
        Destroy(gameObject, _lifeBullet);
    }

    public void ShotBullet(Vector3 direct)
    {       
        _rb.AddForce(direct.normalized * _speed, ForceMode2D.Impulse);
    }

    public void GetPropertyBullet(float damageWeapon, float speedBullet)
    {
        _damage = damageWeapon;
        _speed = speedBullet;       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterVitalsStatistic health = collision.gameObject.GetComponent<CharacterVitalsStatistic>();

        if (health != null)
        {
            _touch++;

            health.TakeDamage(_damage / _touch);
            health.ReduceStamina(40f);

            if (_touch >= _breakingCapacity)
            {             
                Destroy(gameObject, 2f);
            }
        }
    }
}
