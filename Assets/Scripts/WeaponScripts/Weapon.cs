using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponType;
using CharacterModification;

[System.Serializable]
public abstract class Weapon : Item
{    
    [SerializeField] private TypeWeapon _weaponType;

    [SerializeField] private PropertyWeapon _wireWeapon;

    public PropertyWeapon WireWeapon { get { return _wireWeapon; } private set { } }

    protected abstract void Attack();

    public abstract void ControlWeapon(IControlWeapon controlWeapon);   

    [System.Serializable]
    public struct PropertyWeapon
    {        
        [SerializeField] private AudioSource _sourceWeapon;        

        [SerializeField] private float _minDamage;
        [SerializeField] private float _maxDamage;

        public float MinDamage { get { return _minDamage; } private set { } }
        public float MaxDamage { get { return _maxDamage; } private set { } }        

        public void PlaySound(AudioClip sound)
        {            
            _sourceWeapon.PlayOneShot(sound);
        }
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
