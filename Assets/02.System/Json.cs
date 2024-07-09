using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Json : MonoBehaviour
{
    [ContextMenu("ReadJson")]
    public void ReadJson()
    {
        string jsonData = JsonUtility.ToJson(EquipmentUI.Dataes);
        string path = Path.Combine(Application.streamingAssetsPath, "Data.json");
        File.WriteAllText(path, jsonData);
        Debug.Log("Á÷·ÄÈ­");
    }
    [ContextMenu("LoadJson")]
    public void LoadJson()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Data.json");
        string jsonData = File.ReadAllText(path);
        EquipmentUI.Dataes = JsonUtility.FromJson<DataSave>(jsonData);
        EquipmentUI.Equipments = EquipmentUI.Dataes.Datass.Equipments;
        Debug.Log(EquipmentUI.Equipments.Count);
    }
}
