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

    public int RandomDraw(DrawProb[] prob) //각 장비 랭크별 확률 배열
    {
        float standardNum = StandardNumSet(); //중간값 구하기
        float Beweight = 0; //데이터 반영전 가중치
        float Afweight = 0; //데이터 반영후 가중치
        int count = 0;
        while (count < prob.Length)
        {
            Afweight += prob[count].ReProb(); //내림 차순한 데이터를 순차적으로 넣어줌
            if (standardNum >= Beweight && standardNum <= Afweight) //중간값이 현재 어느 랭크 갑사 사이에 있는지 확인
            {
                return count;
            }
            Beweight += prob[count].ReProb();
            count++;
        }
        return count;
    }

    public float StandardNumSet() //중간값 
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


