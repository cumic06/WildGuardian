using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : EquipmentUI, IVisitElement
{
    [SerializeField] private Image slot;
    [HideInInspector] public Image Image;
    public static Inventory Instance;
    public static ObseverManager Inventory_obsever = new ObseverManager();
    private I_Obsever mouting_obseverFunc = new ObseverFunc();
    private void Awake()
    {
        Instance = this;
        //InventorySet();
        equipmentData.EquipmentInfoDataSet();
        StartSet();
    }

    private void StartSet()
    {
        mouting_obseverFunc.Func = () => { EquipmentActive(equipmentSlot, 1); };
        OptionPanel.Mouting_obsever.obseverList.Add(mouting_obseverFunc);
        clickFunc = (image) =>
        {
            Image = image;
            OptionUISet(image.sprite, ButtonType.Mounting);
            Inventory_obsever.Notify();
            //equipmentData.EquipmentInfoData[image.sprite]
        };
    }

    public void InventoryAdd(Sprite newEquipment)
    {
        equipments.Add(Instantiate(slot));
        equipments.Last().transform.GetChild(0).TryGetComponent(out Image equipmentImage);
        equipmentImage.sprite = newEquipment;
        equipments.Last().transform.parent = transform.GetChild(0);
    }

    public void Accept(IVisit visitor)
    {
        visitor.Visit(this);
    }
}
