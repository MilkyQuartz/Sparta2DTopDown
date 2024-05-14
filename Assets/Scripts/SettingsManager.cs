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
    public TMP_InputField playerNameInput;
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
        gameManager.SetIsInputActive(true);
        playerNameInput.text = "";
        blueImage.color = Color.white;
        yellowImage.color = Color.white;
        bgSelectImg.SetActive(true);
        isYellowSelected = false;
        isBlueSelected = false;

    }

    public void PeopleBtnClick()
    {
        currentPeopleImg.SetActive(true);
    }

    public void CloseSetBtnClick()
    {
        bgSelectImg.SetActive(false);
        gameManager.SetIsInputActive(false);
    }
    public void ClosePeopleBtnClick()
    {
        currentPeopleImg.SetActive(false);
    }
    public void YellowImageClick()
    {
        yellowImage.color = Color.yellow; 
        blueImage.color = Color.white;   
        isYellowSelected = true;         
        isBlueSelected = false;          
        ChangeCharacter("YellowPlayer"); 
    }

    public void BlueImageClick()
    {
        blueImage.color = Color.blue;   
        yellowImage.color = Color.white; 
        isBlueSelected = true;           
        isYellowSelected = false;        
        ChangeCharacter("BluePlayer");
    }
}
