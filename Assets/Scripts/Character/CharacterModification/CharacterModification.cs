using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterModification
{
    public interface ICharacter : IControlWeapon
    {
        public Vector3 Movement();

        public bool DesireWalk();

        public bool DesireRun();

        public bool DesireJump();

        public int SwitchWeapon(ref int number, int maxCountWeapon, IReadOnlyList<Weapon> image, int minCountWeapon = 0);
    }

    public interface IControlWeapon
    {
        public bool Attack();

        public bool Recharge();
    }

    public interface ICharacteristicHealth
    {
        public void TakeDamage(float damage);

        public void RestoreHealth(float valueHealth);        
    }
    
    public interface ICharacteristicStamina
    {
        public void ReduceStamina(float valueStamina);

        public void RestoreStamina(float valueStamina);                
    }
    
    public interface ICharacteristicEnergy
    {
        public void ReduceEnergy(float valueEnergy);

        public void RestoreEnergy(float valueEnergy);
    }


}
