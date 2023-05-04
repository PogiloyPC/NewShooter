using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public Transform playerPos;
    public Vector2 offset;
    public float dampingMoveX, dampingMoveY;

    void LateUpdate()
    {
        Vector3 posPlayer = new Vector3(playerPos.position.x + (offset.x * playerPos.localScale.x), playerPos.position.y + offset.y, -10);
        Vector3 dampX = Vector3.Lerp(transform.position, posPlayer, dampingMoveX * Time.deltaTime);
        Vector3 dampY = Vector3.Lerp(transform.position, posPlayer, dampingMoveY * Time.deltaTime);
        transform.position = new Vector3(dampX.x, dampY.y, posPlayer.z);
    }
}
