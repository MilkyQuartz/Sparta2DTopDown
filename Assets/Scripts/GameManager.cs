using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string currentTime = GetCurrentTime();
        timeTxt.text = currentTime;
    }

    public static string GetCurrentTime()
    {
        return DateTime.Now.ToString(("HH:mm"));
    }
}
