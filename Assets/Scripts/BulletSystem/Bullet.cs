using UnityEngine;
using GunSystem.Bullet;

public class Bullet : MonoBehaviour
{
    [SerializeField] private TypeBullet _typeBullet;
    [SerializeField] private Rigidbody2D _rb;    

    [SerializeField] private BoxCollider2D _box;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private TrailRenderer _trail;

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
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            _touch++;

            health.TakeDamage(_damage / _touch);

            if (_touch >= _breakingCapacity)
            {
                _box.enabled = false;
                _sprite.enabled = false;
                _trail.enabled = false;

                Destroy(gameObject, 2f);
            }
        }
    }
}
