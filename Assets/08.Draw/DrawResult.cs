using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DrawResult : MonoBehaviour, IVisitElement
{
    public Image EquipmentIMG;
    public Text Lank;
    public I_Obsever DrawOb = new ObseverFunc();
    private Result result;

    public void Accept(IVisit visitor)
    {
        visitor.Visit(this);
    }

    public void Start()
    {
        DrawOb.Func = () =>
        {
            transform.GetChild(0).gameObject.SetActive(true);
            result = ScriptableObjectSet.Instance.DrawResults.ResultInfo.Dequeue();
            EquipmentIMG.sprite = result.Equipment_Img;
            Lank.text = result.equipmentType.ToString();
        };
        DrawSystem.DrawComplete.AddObsever(DrawOb);
    }
}
