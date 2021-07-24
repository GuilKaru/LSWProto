using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hide the WarningTexts
public class HideText : MonoBehaviour
{
    private float timeTillHide;

    private void Start()
    {
        timeTillHide = 3f;
    }
    // Update is called once per frame
    void Update()
    {
        timeTillHide -= Time.deltaTime;
        if(timeTillHide <= 0f)
        {
            timeTillHide = 3f;
            gameObject.SetActive(false);
        }
    }
}
