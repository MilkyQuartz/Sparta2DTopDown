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
    private Dictionary<int, GameObject> playerList = new Dictionary<int, GameObject>(); // �÷��̾� ���
    private int nextPlayerId = 1;


    public void AddPlayer(string playerName)
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

    // NPC �±׸� ���� ������Ʈ�� �̸� ����Ʈ�� �ֱ�
    public void AddTutorName()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("NPC"))
            {
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                foreach (Transform child in children)
                {
                    if (child.name == "TutorNameTxt")
                    {
                        Text textComponent = child.GetComponent<Text>();
                        if (textComponent != null)
                        {
                            string tutorName = textComponent.text;
                            AddPlayer(tutorName);
                        }
                        break; 
                    }
                }
            }
        }
    }

    void Start()
    {
        // �̰͵� �� �̸��� �ƴ϶� Player �±׷� �����ؾ��� �����丵 �ʿ�
        string myName = PlayerPrefs.GetString("PlayerName");

        AddPlayer(myName);

        AddTutorName(); 
    }
}
