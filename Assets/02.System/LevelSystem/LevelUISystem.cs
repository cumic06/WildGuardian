using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUISystem : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;

    private void Start()
    {
        LevelSystem.Instance.OnChangeLevel += LevelUpImage;
    }

    private void LevelUpImage()
    {
        levelUpPanel.SetActive(true);
    }
}