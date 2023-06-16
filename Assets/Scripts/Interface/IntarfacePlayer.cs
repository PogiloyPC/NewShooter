using UnityEngine;

public class IntarfacePlayer : MonoBehaviour
{
    [SerializeField] private ViewStateGlove _viewStateGlove;

    [SerializeField] private DisplayVitalStatistics _displayVitalStatistics;

    [SerializeField] private SmartGlove _smartGlove;

    [SerializeField] private PlayerVitalStatistic _vitalStatistics;

    [SerializeField] private ViewWeaponPlayer _viewWeaponPlayer;

    [SerializeField] private CharacterPlayer _player;

    private void Awake()
    {
        _smartGlove.AddListen(_viewStateGlove);

        _player.AddViewWeapon(_viewWeaponPlayer);
    }      
}
