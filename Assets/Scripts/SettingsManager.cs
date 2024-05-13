using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public Image yellowImage;
    public Image blueImage;
    public GameObject bgSelectImg;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance; 
    }

    public void ChangeCharacter(string characterName)
    {
        PlayerPrefs.SetString("selectCharacter", characterName);
    }


    public void SettingBtnClick()
    {
        bgSelectImg.SetActive(true);
    }

    public void CloseBtnClick()
    {
        bgSelectImg.SetActive(false);
    }
}
