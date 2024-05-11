using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum Character
{
    Yellow,
    Blue
}

public class PlayerManager : MonoBehaviour
{

    public GameObject bgSelectCharacter;
    public GameObject yellowCharacter;
    public GameObject blueCharacter;
    public GameObject closeBtn;
    [SerializeField] private TMP_InputField playerName = null;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
