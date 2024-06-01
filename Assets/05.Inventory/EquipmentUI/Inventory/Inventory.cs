using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : EquipmentUI
{
    [SerializeField] private Image slot;
    public static ObseverManager Inventory_obsever = new ObseverManager();
    private ObseverFunc mouting_obseverFunc = new();
    private void Awake()
    {
        InventorySet();
        equipmentData.EquipmentInfoDataSet();
        StartSet();
    }

    private void StartSet()
    {
        mouting_obseverFunc.SumDele(mouting_obseverFunc.Panel = (panel) => { EquipmentActive(equipmentSlot, 1); });
        OptionPanel.Mouting_obsever.obseverList.Add(mouting_obseverFunc);
        clickFunc = (image) =>
        {
            OptionUISet(image.sprite, ButtonType.Mounting);
            Inventory_obsever.Notify(equipmentData.EquipmentInfoData[image.sprite]);
        };
    }

    private void InventorySet()
    {
        for (int i = 0; i < equipmentData.EquipmentInfo.Length; i++)
        {
            equipments.Add(Instantiate(slot));
            equipments.Last().transform.GetChild(0).TryGetComponent(out Image equipmentImage);
            equipmentImage.sprite = equipmentData.EquipmentInfo[i].GetUnitType();
            equipments.Last().transform.parent = transform.GetChild(0);
        }
    }


}
