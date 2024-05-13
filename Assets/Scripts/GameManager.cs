using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public GameObject playerContainer;
    public Text timeTxt;
    public Text playerNameText;

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        string selectCharacter = PlayerPrefs.GetString("selectCharacter");
        float playerPosX = PlayerPrefs.GetFloat("PlayerPositionX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPositionY");
        float playerPosZ = PlayerPrefs.GetFloat("PlayerPositionZ");

        GameObject selectedCharacterPrefab = null;

        if (!string.IsNullOrEmpty(selectCharacter))
        {
            // 선택된 캐릭터 프리팹 찾기
            selectedCharacterPrefab = Resources.Load<GameObject>(selectCharacter);
        }

        if (selectedCharacterPrefab != null && playerContainer != null)
        {
            // 플레이어 오브젝트의 자식으로 추가
            GameObject player = Instantiate(selectedCharacterPrefab, new Vector3(playerPosX, playerPosY, playerPosZ), Quaternion.identity);
            player.transform.parent = playerContainer.transform;

        }
        playerNameText.text = playerName;
    }

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