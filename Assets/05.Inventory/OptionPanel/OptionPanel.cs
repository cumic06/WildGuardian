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
    public Text EquipmentName;
    public Image EquipmentImage;
    public Text EquipmentRank;
    public Text EquipmentLv;
    public Text EquipmentExplain;

    private void Awake()
    {
        mountingBtn.onClick.AddListener(() => Mounting());
        clearBtn.onClick.AddListener(() => Clear());
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
