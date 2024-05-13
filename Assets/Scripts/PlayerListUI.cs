using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListUI : MonoBehaviour
{
    public Transform content;
    public Font customFont;
    public Color textColor = Color.black;
    public int fontSize = 50; 
    public FontStyle fontStyle = FontStyle.Bold; 
    private Dictionary<int, GameObject> playerList = new Dictionary<int, GameObject>(); // 플레이어 목록
    private int nextPlayerId = 1; 

    // 플레이어 목록에 플레이어를 추가하는 함수
    public void AddPlayerToList(string playerName)
    {
        GameObject entry = new GameObject("PlayerEntry_" + nextPlayerId);
        Text textComponent = entry.AddComponent<Text>();
        textComponent.text = playerName;
        textComponent.font = customFont; 
        textComponent.fontSize = fontSize; 
        textComponent.color = textColor; 
        textComponent.fontStyle = fontStyle; 

        entry.transform.SetParent(content, false);
        entry.transform.SetAsFirstSibling();

        playerList.Add(nextPlayerId, entry);

        nextPlayerId++;
    }

    public void RemovePlayerFromList(int playerId)
    {
        Destroy(playerList[playerId]);
        playerList.Remove(playerId);
    }

    void Start()
    {
        string myName = PlayerPrefs.GetString("PlayerName");

        AddPlayerToList(myName);
    }
}
