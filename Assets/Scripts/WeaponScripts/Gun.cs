using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunSystem.Bullet;
using CharacterModification;

public class Gun : Weapon
{
    [Header("SoundGun")]
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _rechargeSound;
    [SerializeField] private AudioClip _noBullet;  
    [Header("PropertyGun")]
    [SerializeField] private Transform[] _startPosShot;
    [SerializeField] private Transform[] _directShot;

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

    public int CountBulletInCage { get { return _countBulletInCage; } private set { } }

    [SerializeField] private TypeBullet _typeBullet;

    [SerializeField] private Bullet _bulletObj;

    [Header("RechargeGun")]
    private bool _recharged = true;

    [SerializeField, Range(1f, 10f)] private float _rechargeWeapon;
    private float _currentRateOfFire;

    private int _countClickForRecharge;
    private int _maxCountClickForRecharge = 2;
    
    public int Cage;

    private IEnumerator _recharge;

    private void Awake()
    {              
        CheckBulletInCageAtStart();        

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
            MinimizationGunSpread();

            RateOfFire();
            if (control.Attack())
                Attack();

            if (control.Recharge() || _countClickForRecharge >= _maxCountClickForRecharge)
                ReloadRecharge(Cage);
        }
    }

    protected override void Attack()
    {
        if (_currentRateOfFire <= 0 && _recharged)
        {
            if (_countBulletInCage > 0f)
            {
               PlaySound(_shotSound);

                ReloadCountBulletGun(-1);

                for (int i = 0; i < _directShot.Length; i++)
                {
                    float weaponSpread = Random.Range(-_weaponSpread, _weaponSpread);

                    Bullet bullet = Instantiate(_bulletObj, _startPosShot[i].position, _bulletObj.transform.rotation);                    

                    bullet.GetPropertyBullet(Random.Range(MinDamage, MaxDamage), _speedBullet);
                    bullet.ShotBullet(new Vector3(_directShot[i].position.x, _directShot[i].position.y + weaponSpread) - transform.position);

                    ReloadGunSpread();
                }
            }
            else
            {
                _countClickForRecharge++;

                PlaySound(_noBullet);
            }

            _currentRateOfFire = _rateOfFire;
        }
    }

    private void RateOfFire()
    {
        _currentRateOfFire -= Time.deltaTime;
    }

    private void ReloadRecharge(int cage)
    {
        _countClickForRecharge -= _countClickForRecharge;

        _recharge = Recharge(cage);

        if (_countBulletInCage < _maxCountBulletInCage && _recharged && Cage > 0)
            StartCoroutine(_recharge);
    }

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

    private IEnumerator Recharge(int allBullet)
    {
        _recharged = false;

       PlaySound(_rechargeSound);

        int cage = Mathf.Clamp(_maxCountBulletInCage - _countBulletInCage, 0, allBullet);

        yield return new WaitForSeconds(_rechargeWeapon);

        ReloadCountBulletGun(cage);

        _recharged = true;
    }       
}
