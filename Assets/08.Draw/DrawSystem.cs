using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;
using System.Linq;

public class DrawSystem : MonoBehaviour,IVisit
{
    public DrawData DrawMachine;
    public static ObseverManager DrawComplete = new();
    public Button bt;
    public float SumProb;
    private uint[] RandNum;
    public void Start()
    {
        //Random.value
        RandNum = new uint[2] { (uint)Random.Range(0, int.MaxValue), (uint)Random.Range(0, int.MaxValue) };
        bt.onClick.AddListener(() => RandomDraw());
        DrawDataSet();
    }
    public void RandomDraw()
    {
        float standardNum = StandardNumSet();
        float Beweight = 0;
        float Afweight = 0;
        int count = 0;
        while (count < DrawMachine.DrawInfos.Length)
        {
            Afweight += DrawMachine.DrawInfos[count].Prob;
            if (standardNum >= Beweight && standardNum <= Afweight)
            {
                Debug.Log($"{DrawMachine.DrawInfos[count].equipmentType}");
                //RandomEquipmentDraw(DrawMachine.DrawInfos[count]);
                break;
            }
            Beweight += DrawMachine.DrawInfos[count].Prob;
            count++;
        }
    }

    //public void RandomEquipmentDraw(DrawInfo drawInfo)
    //{
    //    float standardNum = StandardNumSet();
    //    float Beweight = 0;
    //    float Afweight = 0;
    //    int count = 0;
    //    while (count < drawInfo.DrawEquipmentInfos.Length)
    //    {
    //        Afweight += drawInfo.DrawEquipmentInfos[count].Prob;
    //        if (standardNum >= Beweight && standardNum <= Afweight)
    //        {
    //            ScriptableObjectSet.Instance.DrawResults.ResultInfo.Enqueue(new Result(drawInfo.equipmentType, drawInfo.DrawEquipmentInfos[count].Equipment_Img));
    //            DrawComplete.Notify();
    //            break;
    //        }
    //        Beweight += DrawMachine.DrawInfos[count].Prob;
    //        count++;
    //    }
    //}

    public void DrawDataSet()
    {
        Sum();
        int count = 0;
        //int count2 = 0;
        while (count < DrawMachine.DrawInfos.Length)
        {
            DrawMachine.DrawInfos[count].Prob /= SumProb;
            //while (count2 < DrawMachine.DrawInfos[count].DrawEquipmentInfos.Length)
            //{
            //    DrawMachine.DrawInfos[count].DrawEquipmentInfos[count2].Prob /= SumProb;
            //    count2++;
            //}
            //DrawMachine.DrawInfos[count].DrawEquipmentInfos = DrawMachine.DrawInfos[count].DrawEquipmentInfos.OrderByDescending(prob => prob.Prob).ToArray();
            //count2 = 0;
            count++;
        }
        DrawMachine.DrawInfos = DrawMachine.DrawInfos.OrderByDescending(prob => prob.Prob).ToArray();
    }

    public float Sum()
    {
        int count = 0;
        while (count < DrawMachine.DrawInfos.Length)
        {
            SumProb += DrawMachine.DrawInfos[count].Prob;
            count++;
        }
        return SumProb;
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

    public void Visit(DrawResult element)
    {

    }

    public void Visit(IVisitElement element)
    {
        throw new System.NotImplementedException();
    }
}


