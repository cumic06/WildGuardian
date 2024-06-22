using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class Bar : EquipmentUI
{
    public override void OnClick(PointerEventData eventData)
    {
        EquipmentsOrderby();
    }
    private void EquipmentsOrderby()
    {
        Debug.Log("Á¤·Ä");
        for (int i = 0; i < equipments.Count; i++)
        {
            equipments[i].transform.GetChild(0).TryGetComponent(out Image equipmentImageI);
            for (int j = i; j < equipments.Count; j++)
            {
                equipments[j].transform.GetChild(0).TryGetComponent(out Image equipmentImageJ);
                if (equipmentData.EquipmentInfoData[equipmentImageI.sprite].EquipmentType < equipmentData.EquipmentInfoData[equipmentImageJ.sprite].EquipmentType)
                {
                    (equipments[i].transform.position, equipments[j].transform.position) = (equipments[j].transform.position, equipments[i].transform.position);
                }
            }
        }
        equipments = equipments.OrderByDescending(x => equipmentData.EquipmentInfoData[x.transform.GetChild(0).GetComponent<Image>().sprite].EquipmentType).ToList<Image>();
    }
}
