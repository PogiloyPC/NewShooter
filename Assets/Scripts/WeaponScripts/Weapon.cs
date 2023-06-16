using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponType;
using CharacterModification;

[System.Serializable]
public abstract class Weapon : Item
{    
    [SerializeField] private float _minDamage;
    [SerializeField] private float _maxDamage;

    public float MinDamage { get { return _minDamage; } private set { } }
    public float MaxDamage { get { return _maxDamage; } private set { } }

    [SerializeField] private TypeWeapon _weaponType;
        
    [SerializeField] private AudioSource _sourceWeapon;    

    protected abstract void Attack();

    public abstract void ControlWeapon(IControlWeapon controlWeapon);  
    
    public void PlaySound(AudioClip sound)
    {
        _sourceWeapon.PlayOneShot(sound);
    }
}

namespace GunSystem
{

    namespace Bullet
    {
        public enum TypeBullet
        {
            mm36,
            mm57,
            mm90
        }
    }
}
