using UnityEngine;
using CharacterModification.PlayerModification;
using InterfaceModification;

public class CharacterPlayer : Character
{
    [SerializeField] private Inventory _inventory;

    [SerializeField] private LayerMask _itemLayer;

    [SerializeField] private float _radiusCircle;
    
    [SerializeField] private Transform _posCircle;
    
    private PlayerInput _playerInput;

    private IViewWeapon _viewWeapon;

    protected override void AwakeCharacter()
    {
        _playerInput = new PlayerInput(transform, _viewWeapon);
        _character = _playerInput;        
    }

    public void AddViewWeapon(IViewWeapon viewWeapon)
    {
        _viewWeapon = viewWeapon;
    }

    protected override void StartCharacter()
    {
        
    }

    protected virtual void AwakePlayer()
    {
        
    }

    protected virtual void StartPlayer()
    {

    }

    private void Update()
    {
        ContCharacter();
        PickUpItem();
    }

    protected virtual void UpdatePlayer()
    {

    }


    public void PickUpItem()
    {
        if (_playerInput.TakeAction())
        {
            Collider2D collide = Physics2D.OverlapCircle(_posCircle.position, _radiusCircle, _itemLayer);
            
            if (collide != null)
            {
                ContainerItem item = collide.gameObject.GetComponent<ContainerItem>();

                if (item != null)
                    if (_inventory.CheckSelectedItem(item.ItemContainer))
                        Destroy(item.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_posCircle.position, _radiusCircle);
    }
}
