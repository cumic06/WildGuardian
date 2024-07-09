using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using Unity.VisualScripting;

public class Bar : EquipmentUI
{
    public static Bar Instance;
    public void Awake()
    {
        Instance = this;
        
    }
    public override void OnClick(PointerEventData eventData)
    {
        EquipmentsOrderby();
    }
    public void EquipmentsOrderby()
    {
        List<Image> EquipLank = new List<Image>();
        List<Vector3> EquipPos = new List<Vector3>();
        Equipments.ForEach(x => EquipPos.Add(x.transform.position));
        EquipLank = Equipments.OrderByDescending(x => equipmentData.EquipmentInfoData[x.transform.GetChild(0).GetComponent<Image>().sprite].Item1).ToList();
        for (int i = 0; i < EquipLank.Count; i++)
        {
            Debug.Log(EquipLank.Count);
            EquipLank[i].transform.position = EquipPos[i];
        }
        
    }
}
