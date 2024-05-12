using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class StartSceneManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    private string playerName;
    public GameObject warningMessage;
    public GameObject bgCharacter;
    public GameObject bgSelectCharacter;
    public Image yellowImage;
    public Image blueImage;
    private bool isYellowSelected = false;
    private bool isBlueSelected = false;
    public GameObject yellowCharacter;
    public GameObject blueCharacter;
    private GameObject selectCharacter;

    public void Join()
    {
        playerName = playerNameInput.text;
        if (!string.IsNullOrEmpty(playerName) && playerName.Length >= 2 && playerName.Length <= 10 && (isYellowSelected || isBlueSelected))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            Debug.Log($"닉네임: {playerName}");

            selectCharacter = isYellowSelected ? yellowCharacter : blueCharacter;
            if (selectCharacter != null)
            {
                PlayerPrefs.SetString("selectCharacter", selectCharacter.name);
                PlayerPrefs.SetFloat("PlayerPositionX", 0);
                PlayerPrefs.SetFloat("PlayerPositionY", 0);
                PlayerPrefs.SetFloat("PlayerPositionZ", 0);


                Debug.Log($"캐릭터: {selectCharacter.name}");
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                Debug.Log("캐릭터ㅃㄹ");
            }
        }
        else
        {
            Debug.Log("이름ㅃㄹ");
            warningMessage.SetActive(true);
        }
    }

    public void SelectYellow()
    {
        isYellowSelected = true;
        isBlueSelected = false;
        yellowImage.color = Color.white;
        blueImage.color = Color.black;
        bgSelectCharacter.SetActive(false);
        bgCharacter.SetActive(true);
        bgCharacter.GetComponent<Image>().sprite = yellowImage.sprite;
    }

    public void SelectBlue()
    {
        isYellowSelected = false;
        isBlueSelected = true;
        yellowImage.color = Color.black;
        blueImage.color = Color.white;
        bgSelectCharacter.SetActive(false);
        bgCharacter.SetActive(true);
        bgCharacter.GetComponent<Image>().sprite = blueImage.sprite;
    }

    public void ChaImgClick()
    {
        bgCharacter.SetActive(false);
        yellowImage.color = Color.white;
        blueImage.color = Color.white;
        bgSelectCharacter.SetActive(true);
    }

    public void CloseBtnClick()
    {
        bgSelectCharacter.SetActive(false);
        bgCharacter.SetActive(true);
    }
}