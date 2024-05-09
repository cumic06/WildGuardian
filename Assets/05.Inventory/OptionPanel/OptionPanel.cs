using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    public Button mountingBtn;
    public Button clearBtn;
    public static ObseverManager Mouting_obsever = new ObseverManager();
    public static ObseverManager Clear_obsever = new ObseverManager();
    public static ObseverManager StartSet_obsever = new ObseverManager();
    public Text EquipmentName;
    public Image EquipmentImage;
    public Text EquipmentRank;
    public Text EquipmentLv;
    public Text EquipmentExplain;
    public Text PlayerAttackText;
    public Text PlayerHpText;

    private void Awake()
    {
        mountingBtn.onClick.AddListener(() => Mounting());
        clearBtn.onClick.AddListener(() => Clear());
        StartSet_obsever.Notify(gameObject);
        transform.parent.gameObject.SetActive(false);
    }

    private void Mounting()
    {
        Mouting_obsever.Notify(gameObject);
    }

    private void Clear()
    {
        Clear_obsever.Notify(gameObject);
    }
}
public enum ButtonType
{
    Mounting, Clear
}
