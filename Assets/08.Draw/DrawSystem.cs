using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;
using System.Linq;

public class DrawSystem : MonoBehaviour, IVisit
{
    public DrawData DrawMachine;
    public EquipmentData DrawChildData;
    private uint[] RandNum;
    private Sprite DrawResultImg;
    public void Start()
    {
        //Random.value
        RandNum = new uint[2] { (uint)Random.Range(0, int.MaxValue), (uint)Random.Range(0, int.MaxValue) };
    }

    public int RandomDraw(DrawProb[] prob)
    {
        float standardNum = StandardNumSet();
        float Beweight = 0;
        float Afweight = 0;
        int count = 0;
        while (count < prob.Length)
        {
            Afweight += prob[count].ReProb();
            if (standardNum >= Beweight && standardNum <= Afweight)
            {
                return count;
            }
            Beweight += prob[count].ReProb();
            count++;
        }
        return count;
    }

    public float StandardNumSet()
    {
        uint num1 = RandNum[0];
        uint num2 = RandNum[1];
        RandNum[0] = num2;
        num1 ^= num1 << 23;
        num2 ^= num2 >> 17;
        num1 ^= num2;
        RandNum[1] = num1 + num2;
        return RandNum[1] / (float)uint.MaxValue;
    }

    private int FindLank(int ParentIndex)
    {
        int count = 0;
        while (count < DrawChildData.EquipmentInfo.Length)
        {
            if (DrawChildData.EquipmentInfo[count].EquipmentRank == DrawMachine.DrawInfos[ParentIndex].EquipmentRank)
                break;
            count++;
        }

        return count;
    }

    private void SpendDrawUI(DrawUI element)
    {
        int ParentIndex = RandomDraw(DrawMachine.DrawInfos);
        int count = FindLank(ParentIndex);
        int DrawResultIndex = RandomDraw(DrawChildData.EquipmentInfo[count].EquipmentInfoInternal);
        DrawResultImg = DrawChildData.EquipmentInfo[count].EquipmentInfoInternal[DrawResultIndex].EquipmentImage;
        element.UISet(DrawMachine.DrawInfos[ParentIndex].EquipmentRank.ToString(), DrawResultImg);
    }

    public void Visit(DrawUI element)
    {
        //element.Accept(this);
        SpendDrawUI(element);
    }

    public void Visit(Inventory element)
    {
        element.InventoryAdd(DrawResultImg);
    }

    public void Visit(IVisitElement element)
    {
        //throw new System.NotImplementedException();
    }
}


