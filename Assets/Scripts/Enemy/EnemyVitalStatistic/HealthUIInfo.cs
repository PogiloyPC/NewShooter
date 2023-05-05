using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIInfo : MonoBehaviour
{    
    [SerializeField] private AnimationCurve upImage;
    [SerializeField] private Text textInfo;
    private float currentTime, finishTime;
    
    void Start()
    {
        finishTime = upImage.keys[upImage.keys.Length - 1].time;        
        StartCoroutine("InfoDamage");
    }
    
    public IEnumerator InfoDamage()
    {
        Vector2 pos = transform.position;
        while (true)
        {
            transform.position = new Vector2(pos.x, pos.y + upImage.Evaluate(currentTime));
            currentTime += Time.deltaTime;
            textInfo.CrossFadeAlpha(1f, 0.1f, false);
            if (currentTime >= finishTime)
            {
                Destroy(gameObject);
                StopCoroutine("InfoDamage");
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
