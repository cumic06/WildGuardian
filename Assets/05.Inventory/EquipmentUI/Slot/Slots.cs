using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : EquipmentUI
{
    [SerializeField] private Equipment[] equipments = new Equipment[4];
    [SerializeField] private UnitData playerData;
    private EquipmentInfo equipmentInfo;
    private ObseverFunc Inventory_obseverFunc = new();
    private ObseverFunc Mouting_obseverFunc = new();
    private ObseverFunc Clear_obseverFunc = new();
    public void Awake()
    {
        ObseverSet();
        StartSet();
    }

    private void ObseverSet()
    {
        Inventory_obseverFunc.Obsever = (a) => equipmentInfo = a.ConvertTo<EquipmentInfo>();
        Inventory.Inventory_obsever.obseverList.Add(Inventory_obseverFunc);
        Mouting_obseverFunc.Obsever = (panel) => { panel.ConvertTo<GameObject>().transform.parent.gameObject.SetActive(false); Mounting(); };
        OptionPanel.Mouting_obsever.obseverList.Add(Mouting_obseverFunc);
        Clear_obseverFunc.Obsever = (panel) => { panel.ConvertTo<GameObject>().transform.parent.gameObject.SetActive(false); Clear(); EquipmentActive(equipmentSlot, 2);  };
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
        foreach (var equipment in equipments)
        {
            if (equipmentInfo.GetEquipmentType().Equals(equipment.equipmentType))
            {
                equipment.TryGetComponent(out Image image);
                image.transform.GetChild(0).TryGetComponent(out Image equipmentImage);
                equipmentImage.sprite = equipmentInfo.GetUnitType();
                playerData.unitInfo.SumUnitData(equipmentInfo.GetUnitStat());
                break;
            }
        }
    }

    private void Clear()
    {
        playerData.unitInfo.MinusUnitData(equipmentData.EquipmentInfoData[equipmentSlot.sprite].GetUnitStat());
    }
}
