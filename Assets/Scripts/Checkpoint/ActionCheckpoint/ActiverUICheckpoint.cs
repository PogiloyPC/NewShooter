using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverUICheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject UICheckpoint;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField, Range(0, 1)] private float newSize;
    private Vector2 size;

    private void Start()
    {
        UICheckpoint.SetActive(false);
        size = transform.localScale;
    }

    private void OnMouseDown()
    {
        UICheckpoint.SetActive(true);
    }

    private void OnMouseEnter()
    {
        sprite.color = new Color(27f, 255f, 0f);
        transform.localScale = new Vector2(size.x + newSize, size.y + newSize);
    }

    private void OnMouseExit()
    {
        sprite.color = Color.white;
        transform.localScale = new Vector2(size.x, size.y);
    }
}
