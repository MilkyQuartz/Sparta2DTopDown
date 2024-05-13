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
    public GameObject currentPeopleImg;
    private bool isYellowSelected = false;
    private bool isBlueSelected = false;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance; 
    }

    public void ChangeCharacter(string characterName)
    {
        PlayerPrefs.SetString("selectCharacter", characterName);
        gameManager.UpdatePlayerInfo();
    }


    public void SettingBtnClick()
    {
        bgSelectImg.SetActive(true);
        isYellowSelected = false;
        isBlueSelected = false;

    }

    public void PeopleBtnClick()
    {
        currentPeopleImg.SetActive(true);
    }

    public void CloseBtnClick()
    {
        bgSelectImg.SetActive(false);
    }
    public void ClosePeopleBtnClick()
    {
        currentPeopleImg.SetActive(false);
    }
    public void YellowImageClick()
    {
        yellowImage.color = Color.green; 
        blueImage.color = Color.white;   
        isYellowSelected = true;         
        isBlueSelected = false;          
        ChangeCharacter("YellowPlayer"); 
    }

    public void BlueImageClick()
    {
        blueImage.color = Color.green;   
        yellowImage.color = Color.white; 
        isBlueSelected = true;           
        isYellowSelected = false;        
        ChangeCharacter("BluePlayer");
    }
}
