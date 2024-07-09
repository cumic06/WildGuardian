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
        Dataes.Datass = new SaveDatas<List<Image>, List<GameObject>>(Equipments, disappearImage);
        json.LoadJson();
        StartInventory();
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
        //Bar.Instance.EquipmentsOrderby();
        Image sprite = Instantiate(slot);
        Equipments.Add(sprite);
        Equipments.Last().transform.GetChild(0).TryGetComponent(out Image equipmentImage);
        equipmentImage.sprite = newEquipment;
        Equipments.Last().transform.parent = transform.GetChild(0);
        //Debug.Log(equipments_Tr.Last().position);
        json.ReadJson();
    }

    public void StartInventory()
    {
        if (Equipments.Count != 0)
        {
            Debug.Log("»ý¼º");
            foreach (var equip in Equipments)
            {
                Image sprite = Instantiate(slot);
                sprite.transform.GetChild(0).TryGetComponent(out Image equipmentImage);
                equipmentImage = equip;
                sprite.transform.parent = transform.GetChild(0);
            }
        }
    }

    public void Accept(IVisit visitor)
    {
        visitor.Visit(this);
    }
}
