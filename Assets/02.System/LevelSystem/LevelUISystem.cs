using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUISystem : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private Text[] levelUpNameText;
    [SerializeField] private Text[] levelUpExplanText;

    private void Start()
    {
        LevelSystem.Instance.OnChangeLevel += (a) => LevelUpImage(a);
    }

    private void LevelUpImage(LevelUpStatInfo[] levelUpStatInfo)
    {
        levelUpPanel.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            levelUpNameText[i].text = levelUpStatInfo[i].name;
            levelUpExplanText[i].text = levelUpStatInfo[i].explan;
        }
    }
}