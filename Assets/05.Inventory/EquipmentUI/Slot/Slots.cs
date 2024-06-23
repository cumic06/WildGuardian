using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slots : EquipmentUI
{
    public static Slots Instance;
    public Equipment[] EquipmentsPart = new Equipment[4];
    public UnitData PlayerData;
    private EquipmentInfoInternal equipmentInfo;
    private I_Obsever Inventory_obseverFunc = new ObseverFunc();
    private I_Obsever Mouting_obseverFunc = new ObseverFunc();
    private I_Obsever Clear_obseverFunc = new ObseverFunc();
    private I_Obsever StartSet_obseverFunc = new ObseverFunc();
    public void Awake()
    {
        Instance = this;
        ObseverSet();
        StartSet();
        //PlayerText();
    }

    private void ObseverSet()
    {
        OptionPanel optionPanel;
        StartSet_obseverFunc.Func = () =>
        {
            optionPanel = OptionPanel.Instance;
            PlayerText(optionPanel);
        };
        OptionPanel.StartSet_obsever.AddObsever(StartSet_obseverFunc);
        Inventory_obseverFunc.Func = () => equipmentInfo = Inventory.Instance.equipmentData.EquipmentInfoData[Inventory.Instance.Image.sprite].Item2;
        Inventory.Inventory_obsever.obseverList.Add(Inventory_obseverFunc);
        Mouting_obseverFunc.Func = () =>
        {
            optionPanel = OptionPanel.Instance;
            optionPanel.transform.parent.parent.gameObject.SetActive(false);
            Mounting();
            PlayerText(optionPanel);
        };
        OptionPanel.Mouting_obsever.obseverList.Add(Mouting_obseverFunc);
        Clear_obseverFunc.Func = () =>
        {
            optionPanel = OptionPanel.Instance;
            optionPanel.transform.parent.parent.gameObject.SetActive(false);
            Clear();
            EquipmentActive(equipmentSlot, 2);
            PlayerText(optionPanel);
        };
        OptionPanel.Clear_obsever.obseverList.Add(Clear_obseverFunc);
    }

    private void StartSet()
    {
        clickFunc = (image) =>
        {
            OptionUISet(image.sprite, ButtonType.Clear);
        };
    }

    private void Mounting()
    {
        foreach (var equipment in EquipmentsPart)
        {
            if (equipmentInfo.EquipmentType.Equals(equipment.equipmentType))
            {
                equipment.TryGetComponent(out Image image);
                image.transform.GetChild(0).TryGetComponent(out Image equipmentImage);
                equipmentImage.sprite = equipmentInfo.EquipmentImage;
                PlayerData.unitInfo.SumUnitData(equipmentInfo.UnitStat);
                break;
            }
        }
    }

    private void Clear()
    {
        PlayerData.unitInfo.MinusUnitData(equipmentData.EquipmentInfoData[equipmentSlot.sprite].Item2.UnitStat);
    }

    private void PlayerText(OptionPanel optionPanel)
    {
        UnitStat playerState = PlayerData.unitInfo.GetUnitStat();
        optionPanel.PlayerAttackText.text = $"공격력 : {playerState.attackPower}";
        optionPanel.PlayerHpText.text = $"생명력 : {playerState.maxHp}";
    }
}
