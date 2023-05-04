using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunSystem.Bullet;
using CharacterModification;

public class Gun : Weapon
{    
    [SerializeField] private PropertyGun _wireGun;
    [SerializeField] private SoundGun _sound;

    [SerializeField] private List<Bullet> _bullets;   

    [SerializeField] private bool _keystrokeForShot;
    [SerializeField] private bool _keyHoldForShot;
    private bool _recharged = true;

    [SerializeField, Range(1f, 10f)] private float _rechargeWeapon;
    private float _rateOfFire;

    [SerializeField] private Transform[] _startPosShot;
    [SerializeField] private Transform[] _directShot;

    private int _countClickForRecharge;
    private int _maxCountClickForRecharge = 2;
    public int Cage;

    private IEnumerator _recharge;

    private void Awake()
    {              
        _wireGun.CheckBulletInCageAtStart();

        if (!_keyHoldForShot && !_keystrokeForShot)
            _keystrokeForShot = true;

        if (_directShot.Length > _startPosShot.Length)
        {
            Transform[] array = new Transform[_startPosShot.Length];
            for (int i = 0; i < _startPosShot.Length; i++)
                array[i] = _directShot[i];
            _directShot = array;
        }
        else if (_directShot.Length < _startPosShot.Length)
        {
            Transform[] array = new Transform[_directShot.Length];
            for (int i = 0; i < _directShot.Length; i++)
                array[i] = _startPosShot[i];
            _startPosShot = array;
        }
    }

    private void OnDisable()
    {
        if (!_recharged)
        {
            _countClickForRecharge -= _countClickForRecharge;
            _recharged = true;
            StopCoroutine(_recharge);
        }
    }

    public override void ControlWeapon(IControlWeapon control)
    {
        if (control != null)
        {
            _wireGun.MinimizationGunSpread();

            RateOfFire();
            if (control.Attack())
                Attack();

            if (control.Recharge() || _countClickForRecharge >= _maxCountClickForRecharge)
                ReloadRecharge(Cage);
        }
    }

    protected override void Attack()
    {
        if (_rateOfFire <= 0 && _recharged)
        {
            if (_wireGun.CountBulletInCage > 0f)
            {
                WireWeapon.PlaySound(_sound.ShotSound);

                _wireGun.ReloadCountBulletGun(-1);

                for (int i = 0; i < _directShot.Length; i++)
                {
                    float weaponSpread = Random.Range(-_wireGun.WeaponSpread, _wireGun.WeaponSpread);

                    Bullet bullet = Instantiate(_wireGun.BulletObj, _startPosShot[i].position, _wireGun.BulletObj.transform.rotation);                    

                    bullet.GetPropertyBullet(Random.Range(WireWeapon.MinDamage, WireWeapon.MaxDamage), _wireGun.SpeedBullet);
                    bullet.ShotBullet(new Vector3(_directShot[i].position.x, _directShot[i].position.y + weaponSpread) - transform.position);

                    _wireGun.ReloadGunSpread();
                }
            }
            else
            {
                _countClickForRecharge++;

                WireWeapon.PlaySound(_sound.NoBullet);
            }

            _rateOfFire = _wireGun.RateOfFire;
        }
    }

    private void RateOfFire()
    {
        _rateOfFire -= Time.deltaTime;
    }

    private void ReloadRecharge(int cage)
    {
        _countClickForRecharge -= _countClickForRecharge;

        _recharge = Recharge(cage);

        if (_wireGun.CountBulletInCage < _wireGun.MaxCountBulletInCage && _recharged && Cage > 0)
            StartCoroutine(_recharge);
    }

    private IEnumerator Recharge(int allBullet)
    {
        _recharged = false;

        WireWeapon.PlaySound(_sound.RechargeSound);

        int cage = Mathf.Clamp(_wireGun.MaxCountBulletInCage - _wireGun.CountBulletInCage, 0, allBullet);

        yield return new WaitForSeconds(_rechargeWeapon);

        _wireGun.ReloadCountBulletGun(cage);

        _recharged = true;
    }

    [System.Serializable]
    public struct SoundGun
    {
        [SerializeField] private AudioClip _shotSound;
        [SerializeField] private AudioClip _rechargeSound;
        [SerializeField] private AudioClip _noBullet;

        public AudioClip ShotSound { get { return _shotSound; } private set { } }
        public AudioClip RechargeSound { get { return _rechargeSound; } private set { } }
        public AudioClip NoBullet { get { return _noBullet; } private set { } }
    }

    [System.Serializable]
    public struct PropertyGun
    {
        [SerializeField] private int _countBulletInCage;
        [SerializeField] private int _maxCountBulletInCage;
        private int _minCountBulletInCage;

        [SerializeField, Range(1f, 20f)] private float _massGun;
        [SerializeField, Range(0.1f, 6f)] private float _rateOfFire;
        [SerializeField, Range(0.1f, 3f)] private float _recoilGun;
        [SerializeField, Range(9f, 25f)] private float _speedBullet;
        [SerializeField, Range(0.01f, 0.08f)] private float _weaponAccuracy;
        private float _weaponSpread;
        [SerializeField, Range(0.01f, 0.1f)] private float _minWeaponSpread;
        [SerializeField, Range(0.01f, 1f)] private float _maxWeaponSpread;
        [SerializeField, Range(0.1f, 1f)] private float _weaponAimingSpeed;

        [SerializeField] private TypeBullet _typeBullet;

        [SerializeField] private Bullet _bulletObj;

        public int CountBulletInCage { get { return _countBulletInCage; } private set { } }
        public int MinCountBulletInCage { get { return _minCountBulletInCage; } private set { } }
        public int MaxCountBulletInCage { get { return _maxCountBulletInCage; } private set { } }

        public float MassGun { get { return _massGun; } private set { } }
        public float RateOfFire { get { return _rateOfFire; } private set { } }
        public float RecoilGun { get { return _recoilGun; } private set { } }
        public float SpeedBullet { get { return _speedBullet; } private set { } }
        public float WeaponAccuracy { get { return _weaponAccuracy; } private set { } }
        public float WeaponSpread { get { return _weaponSpread; } private set { } }


        public Bullet BulletObj { get { return _bulletObj; } private set { } }

        public TypeBullet TypeBullet { get { return _typeBullet; } private set { } }

        public void CheckBulletInCageAtStart()
        {
            if (_countBulletInCage > _maxCountBulletInCage)
                _countBulletInCage = _maxCountBulletInCage;
        }

        public void ReloadCountBulletGun(int countBullet)
        {
            _countBulletInCage = Mathf.Clamp(_countBulletInCage + countBullet, _minCountBulletInCage, _maxCountBulletInCage);
        }

        public void ReloadGunSpread()
        {
            _weaponSpread = Mathf.Clamp(_weaponSpread + _recoilGun, _minWeaponSpread, _maxWeaponSpread);
        }

        public void MinimizationGunSpread()
        {
            _weaponSpread = Mathf.Lerp(_weaponSpread, _minWeaponSpread - _weaponAccuracy, Time.deltaTime * _weaponAimingSpeed);
        }
    }
}
