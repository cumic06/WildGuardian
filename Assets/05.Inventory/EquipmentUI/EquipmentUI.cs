using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Linq;
using Unity.VisualScripting;

public class EquipmentUI : MonoBehaviour, I_Click
{
    [SerializeField] private GameObject optionPanel;
    public EquipmentData equipmentData;
    protected Image equipmentSlot;
    protected static List<GameObject> disappearImage = new();
    protected static List<Image> equipments = new();
    protected Action<Image> clickFunc = (image) => { };

    public virtual void OnClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Image>().TryGetComponent(out Image image))
        {
            equipmentSlot = image;
            clickFunc(image);
        }
    }

    protected void OptionUISet(Sprite sprite, ButtonType type)
    {
        optionPanel.transform.parent.parent.gameObject.SetActive(true);
        optionPanel.gameObject.TryGetComponent(out OptionPanel optionUI);
        optionUI.EquipmentName.text = $"{equipmentData.EquipmentInfoData[sprite].Item2.EquipmentName}";
        optionUI.EquipmentImage.sprite = equipmentData.EquipmentInfoData[sprite].Item2.EquipmentImage;
        optionUI.EquipmentExplain.text = $"{equipmentData.EquipmentInfoData[sprite].Item2.EquipmentExplain}";
        optionUI.EquipmentRank.text = $"µî±Þ : {equipmentData.EquipmentInfoData[sprite].Item1}";
        if (type.Equals(ButtonType.Mounting))
            optionUI.clearBtn.gameObject.SetActive(false);
        else
            optionUI.clearBtn.gameObject.SetActive(true);
    }

    protected void EquipmentActive(Image image, int num)
    {
        if (num.Equals(1))
        {
            disappearImage.Add(image.gameObject.transform.parent.gameObject);
            image.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if (num.Equals(2))
        {
            for (int i = 0; i < disappearImage.Count; i++)
            {
                if (disappearImage[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite.Equals(image.sprite))
                {
                    disappearImage[i].gameObject.SetActive(true); 
                    image.sprite = null;
                    disappearImage.Remove(disappearImage[i]);
                    break;
                }
            }
        }
    }
}
