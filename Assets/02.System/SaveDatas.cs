using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DataSave
{
    //public List<Data<int, List<Image>, List<GameObject>>> Datas = new List<Data<int, List<Image>, List<GameObject>>>();
    public SaveDatas<List<Image>, List<GameObject>> Datass;
}

[Serializable]
public class SaveDatas<Tvalue, Tvalue2>
{
    //public Tkey Gold;
    public Tvalue Equipments;
    public Tvalue2 DisappearImage;

    public SaveDatas(Tvalue equipments, Tvalue2 disappearImage)
    {
        //Gold = gold;
        Equipments = equipments;
        DisappearImage = disappearImage;
    }
}

