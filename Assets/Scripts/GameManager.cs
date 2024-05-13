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
            // ���õ� ĳ���� �����ս����� �̸����� �ش� �������� ã��
            selectedCharacterPrefab = Resources.Load<GameObject>(selectCharacter);
        }

        if (selectedCharacterPrefab != null && playerContainer != null)
        {
            // ���õ� ĳ���� �������� �÷��̾� �� ������Ʈ�� �ڽ����� �߰�
            GameObject player = Instantiate(selectedCharacterPrefab, new Vector3(playerPosX, playerPosY, playerPosZ), Quaternion.identity);
            player.transform.parent = playerContainer.transform;

            // GameManager�� ���� �÷��̾� �������� ������ ����
            GameManager.Instance.SetPlayerPrefabInstance(player);
        }
        else
        {
            Debug.LogError("�÷��̾� ĳ���� ������ �Ǵ� �÷��̾� �� ������Ʈ�� �������� �ʾҽ��ϴ�.");
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
    // �������� ������ �÷��̾� �������� ������ �����ϴ� �޼���
    public void SetPlayerPrefabInstance(GameObject playerInstance)
    {
        playerPrefabInstance = playerInstance;
    }

    // �������� ������ �÷��̾� �������� ������ ��ȯ�ϴ� �޼���
    public GameObject GetPlayerPrefabInstance()
    {
        return playerPrefabInstance;
    }
}