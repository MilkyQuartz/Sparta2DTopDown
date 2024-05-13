using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class SettingsManager : MonoBehaviour
{
    public Image yellowImage;
    public Image blueImage;
    public GameObject bgSelectImg;
    public void SettingBtnClick()
    {
        bgSelectImg.SetActive(true);

    }
    public void CloseBtnClick()
    {
        bgSelectImg.SetActive(false);
    }
}
