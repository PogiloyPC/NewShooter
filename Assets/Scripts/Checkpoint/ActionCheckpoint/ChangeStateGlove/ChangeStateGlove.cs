using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateGlove : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            this.gameObject.SetActive(false);
        }
    }
}
