using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/UnitData/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    public PlayerStat playerStat;
}

[Serializable]
public struct PlayerStat
{
    public float mana;
    public float coolTimeReduce;
    public float dashPower;
}