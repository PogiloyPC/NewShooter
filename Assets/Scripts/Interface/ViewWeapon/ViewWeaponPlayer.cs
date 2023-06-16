using UnityEngine;
using UnityEngine.UI;
using InterfaceModification;

public class ViewWeaponPlayer : MonoBehaviour, IViewWeapon
{
    [SerializeField] private Image _imageWeapon;

    [SerializeField] private Text _countBullet;

    public void ChangeWeaponImage(Sprite image, int countBullet = 0)
    {       
        _imageWeapon.sprite = image;

        _countBullet.text = countBullet.ToString();
    }
}
