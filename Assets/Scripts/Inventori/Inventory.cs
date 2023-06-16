using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapon;
    [SerializeField] private List<StateSmartGlove> _stateGlove;    
    [SerializeField] private List<Transform> _cells;

    [SerializeField] private GameObject _inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            _inventory.SetActive(!_inventory.activeSelf);
    }

    public bool CheckSelectedItem(Item item)
    {
        bool pickUp;

        switch (item)
        {
            case Weapon:
                Weapon weapon;
                weapon = (Weapon)item;
                _weapon.Add(weapon);

                pickUp = true;
                break;           
            default:
                pickUp = false;
                break;
        }

        if (pickUp)
            DisplayItem(item);

        return pickUp;
    }

    private void DisplayItem(Item item)
    {
        for (int i = 0; i < _cells.Count; i++)
        {            
            Transform cell = _cells[i].GetChild(0);
            Image img = cell.GetComponent<Image>();

            if (img.sprite == null)
            {
                img.enabled = true;
                img.sprite = item.ImageItem;

                break;
            }
        }
    }
}
