using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public GameObject playerContainer;
    public Text timeTxt;
    public GameObject bgSelectImg; 
    public TMP_InputField playerNameInput;

    public Text playerNameText; 

    private GameObject currentCharacterObject;
    private bool isInputActive = false;

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
        UpdatePlayerInfo();
    }

    public void UpdatePlayerInfo()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        string selectCharacter = PlayerPrefs.GetString("selectCharacter");

        GameObject selectedCharacterPrefab = Resources.Load<GameObject>(selectCharacter); 

        if (selectedCharacterPrefab != null && playerContainer != null)
        {

            Destroy(currentCharacterObject);

            GameObject player = Instantiate(selectedCharacterPrefab, playerContainer.transform.position, Quaternion.identity);
            player.transform.parent = playerContainer.transform;

            currentCharacterObject = player;

            SetPlayerInfo(selectedCharacterPrefab, playerName);
        }
    }

    public void SetPlayerInfo(GameObject characterPrefab, string playerName)
    {
        UpdatePlayerName(playerName);
    }
    public void UpdatePlayerName(string playerName)
    {
        playerNameText.text = playerName; 
    }

    public void ChangeName()
    {
        string newName = playerNameInput.text;
        if (!string.IsNullOrEmpty(newName) && newName.Length >= 2 && newName.Length <= 10)
        {
            PlayerPrefs.SetString("PlayerName", newName);
            UpdatePlayerName(newName); 
        }
        else
        {
            Debug.LogWarning("닉네임은 2자 이상, 10자 이하로 입력해주세요.");
        }
    }

    public void OnCheckBtnClick(string characterName)
    {
        ChangeName();
        ChangeCharacter(characterName);
        UpdatePlayerInfo();
        isInputActive = false;
        bgSelectImg.SetActive(false);
    }

    public void ChangeCharacter(string characterName)
    {
        PlayerPrefs.SetString("selectCharacter", characterName);
    }

    void Update()
    {
        string currentTime = GetCurrentTime();
        timeTxt.text = currentTime;
    }

    public static string GetCurrentTime()
    {
        return System.DateTime.Now.ToString(("HH:mm"));
    }
    public void SetIsInputActive(bool isActive)
    {
        isInputActive = isActive;
    }
    public bool GetIsInputActive()
    {
        return isInputActive;
    }
}
