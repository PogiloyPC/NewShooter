using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModification
{
    namespace EnemyModification
    {
        public class EnemyMovable : ICharacter
        {
            private Transform _startPosPatrol;

            private float _rangePatrol;

            public EnemyMovable(Transform transform, float rangePatrol)
            {
                _startPosPatrol = transform;

                _rangePatrol = rangePatrol;
            }

            public Vector3 Movement()
            {
                float rage = Random.Range(-_rangePatrol, _rangePatrol);

                Vector3 directionMove = new Vector3(_startPosPatrol.position.x + rage, _startPosPatrol.position.y);

                return directionMove;
            }

            public bool DesireWalk()
            {
                return true;
            }

            public bool DesireRun()
            {
                return false;
            }

            public bool DesireJump()
            {
                return false;
            }

            public int SwitchWeapon(ref int number, int maxCountWeapon, IReadOnlyList<Weapon> image, int minCountWeapon = 0)
            {

                return number;
            }

            public bool Attack()
            {
                return false;
            }

            public bool Recharge()
            {
                return false;
            }
        }
    }
}
