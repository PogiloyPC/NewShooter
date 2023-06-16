using UnityEngine;

namespace InterfaceModification
{
    public interface IViewStateGlove
    {
        public void ChangeImageStateGlove(Sprite image);

    }
    public interface IViewWeapon
    {
        public void ChangeWeaponImage(Sprite image, int countBullet = 0);

    }
}
