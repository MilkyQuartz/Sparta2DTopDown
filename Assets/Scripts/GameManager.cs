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
    private GameObject playerPrefabInstance;

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
            // 선택된 캐릭터 프리팹스에서 이름으로 해당 프리팹을 찾음
            selectedCharacterPrefab = Resources.Load<GameObject>(selectCharacter);
        }

        if (selectedCharacterPrefab != null && playerContainer != null)
        {
            // 선택된 캐릭터 프리팹을 플레이어 빈 오브젝트의 자식으로 추가
            GameObject player = Instantiate(selectedCharacterPrefab, new Vector3(playerPosX, playerPosY, playerPosZ), Quaternion.identity);
            player.transform.parent = playerContainer.transform;

            // GameManager를 통해 플레이어 프리팹의 참조를 저장
            GameManager.Instance.SetPlayerPrefabInstance(player);
        }
        else
        {
            Debug.LogError("플레이어 캐릭터 프리팹 또는 플레이어 빈 오브젝트가 설정되지 않았습니다.");
        }
        playerNameText.text = playerName;
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
    // 동적으로 생성된 플레이어 프리팹의 참조를 저장하는 메서드
    public void SetPlayerPrefabInstance(GameObject playerInstance)
    {
        playerPrefabInstance = playerInstance;
    }

    // 동적으로 생성된 플레이어 프리팹의 참조를 반환하는 메서드
    public GameObject GetPlayerPrefabInstance()
    {
        return playerPrefabInstance;
    }
}