using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUISystem : MonoSingleton<LevelUISystem>
{
    [SerializeField] private GameObject levelUpPanel;

    private void Start()
    {
        LevelSystem.Instance.OnChangeLevel += LevelUpImageActive;
    }

    private void LevelUpImageActive()
    {
        levelUpPanel.SetActive(true);
    }

    public void LevelUpImageDisable()
    {
        levelUpPanel.SetActive(false);
    }
}