using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _imageItem;
    [SerializeField] private string _nameItem;

    public Sprite ImageItem { get { return _imageItem; } private set { } }
    public string NameItem { get { return _nameItem; } private set { } }
}
