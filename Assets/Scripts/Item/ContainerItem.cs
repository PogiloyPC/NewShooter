using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerItem : MonoBehaviour
{
    [SerializeField] private Item _item;

    public Item ItemContainer { get { return _item; } private set { } }    
}
