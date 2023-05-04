using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private CameraMove cam;
    [SerializeField] private GameObject[] stateCheckpoint;
    [SerializeField] private Rigidbody2D table;
    [SerializeField] private Transform player;
    [SerializeField] private AnimationCurve drop;
    [SerializeField] private AnimationCurve up;    
    [SerializeField] private AnimationCurve tableForceY;
    [SerializeField] private AnimationCurve tableForceX;
    private float currentTime, finishTime;
    private float currentTimeTable, finishTimeTable;    
    private bool isActivated;
    private bool isFind;
    private bool enterCheckpoint;
    private Vector2 startPos;
    private Vector2 startPosTable;
    [SerializeField] private Vector2 offsetCamChp;
    [SerializeField] private Vector2 offsetPlayer;

    void Start()
    {
        startPos = stateCheckpoint[0].transform.position;
        startPosTable = table.gameObject.transform.position;        
        finishTime = drop.keys[drop.keys.Length - 1].time;
        finishTimeTable = tableForceY.keys[tableForceY.keys.Length - 1].time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && isFind)
        {
            cam.playerPos = transform;
            cam.offset = offsetCamChp;
            StartCoroutine("Drop");
            StartCoroutine("TableDroped");
            Camera.main.orthographicSize = 0.4f;
            enterCheckpoint = true;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) && enterCheckpoint)
        {
            table.gameObject.SetActive(false);
            cam.playerPos = player;
            cam.offset = offsetPlayer;
            StopCoroutine("Drop");
            StartCoroutine("Up");
            Camera.main.orthographicSize = 1.2f;
            enterCheckpoint = false;
        }
    }

    public bool ActivateCheckpoint(bool active)
    {
        isActivated = active;
        return isActivated;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFind = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFind = false;
        }
    }

    private IEnumerator Drop()
    {
        for (int i = 0; i < stateCheckpoint.Length; i++)
        {
            stateCheckpoint[i].transform.position = new Vector2(stateCheckpoint[i].transform.position.x, startPos.y);
        }
        Vector2 pos = stateCheckpoint[0].transform.position;
        while (true)
        {
            for (int i = 0; i < stateCheckpoint.Length; i++)
            {
                if (stateCheckpoint[i].activeSelf == false)
                {
                    stateCheckpoint[i].SetActive(true);
                }
                stateCheckpoint[i].transform.position = new Vector2(stateCheckpoint[i].transform.position.x, pos.y + drop.Evaluate(currentTime));
            }
            currentTime += Time.deltaTime;
            if (currentTime >= finishTime)
            {
                currentTime = 0f;
                StopCoroutine("Drop");
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator Up()
    {
        Vector2 pos = stateCheckpoint[0].transform.position;
        while (true)
        {
            for (int i = 0; i < stateCheckpoint.Length; i++)
            {
                stateCheckpoint[i].transform.position = new Vector2(stateCheckpoint[i].transform.position.x, pos.y + up.Evaluate(currentTime));
            }
            currentTime += Time.deltaTime;
            if (currentTime >= finishTime / 5)
            {
                currentTime = 0f;
                stateCheckpoint[1].SetActive(false);
                stateCheckpoint[0].SetActive(false);
                StopCoroutine("Up");
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator TableDroped()
    {
        table.gameObject.transform.position = startPosTable;        
        Vector2 pos = table.gameObject.transform.position;
        table.gameObject.SetActive(true);        
        table.rotation = 12f;
        while (true)
        {
            table.position = new Vector2(pos.x + tableForceX.Evaluate(currentTimeTable) / 2f, pos.y + tableForceY.Evaluate(currentTimeTable));            
            currentTimeTable += 0.006f;            
            if (currentTimeTable >= 0.3f)
            {                            
                table.rotation += 0.9f;
            }
            else if (currentTimeTable >= 0.1f)
            {                            
                table.rotation -= 0.8f;
            }
            if (currentTimeTable >= finishTimeTable)
            {
                table.rotation = 0f;
                currentTimeTable = 0f;
                StopCoroutine("TableDroped");
                break;
            }
            yield return new WaitForSeconds(0.006f);
        }
    }    
}
