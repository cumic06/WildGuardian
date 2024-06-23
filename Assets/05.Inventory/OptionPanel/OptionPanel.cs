using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionPanel : MonoSingleton<OptionPanel>
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

    override protected void Awake()
    {
        base.Awake();
        mountingBtn.onClick.AddListener(() => Mounting());
        clearBtn.onClick.AddListener(() => Clear());
        StartSet_obsever.Notify();
        //gameObject
        transform.parent.parent.gameObject.SetActive(false);
    }

    private void Mounting()
    {
        Mouting_obsever.Notify();
    }

    private void Clear()
    {
        Clear_obsever.Notify();
    }
}
public enum ButtonType
{
    Mounting, Clear
}

