using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModification
{
    namespace PlayerModification
    {        
        public class PlayerInput : ICharacter
        {
            private Transform _transformPlayer;

            public PlayerInput(Transform transform)
            {
                _transformPlayer = transform;
            }

            public Vector3 Movement()
            {
                Vector3 directionMove;

                if (Input.GetKey(KeyCode.D))
                {
                    directionMove = Vector3.right;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    directionMove = Vector3.left;
                }
                else
                {
                    directionMove = Vector3.zero;
                }                    

                if (directionMove != Vector3.zero)
                    _transformPlayer.localScale = new Vector3(Mathf.Abs(_transformPlayer.localScale.x) * directionMove.x, _transformPlayer.localScale.y,
                        _transformPlayer.localScale.z);

                return directionMove;
            }

            public int SwitchWeapon(ref int number, int maxCountWeapon, int minCountWeapon = 0)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");

                if (scroll >= 0.1f)
                    number = Mathf.Clamp(++number, minCountWeapon, maxCountWeapon);
                else if (scroll <= -0.1f)
                    number = Mathf.Clamp(--number, minCountWeapon, maxCountWeapon);

                return number;
            }

            public bool DesireWalk()
            {
                return Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
            }

            public bool DesireRun()
            {
                return Input.GetKey(KeyCode.LeftShift);
            }

            public bool DesireJump()
            {
                return Input.GetKeyDown(KeyCode.W);
            }

            public bool Attack()
            {
                return Input.GetKey(KeyCode.Mouse0); 
            }

            public bool Recharge()
            {
                return Input.GetKeyDown(KeyCode.R);
            }
        }
    }
}
