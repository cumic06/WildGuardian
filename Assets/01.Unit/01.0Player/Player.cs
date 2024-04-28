using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : Unit
{
    public static Player Instance;
    private PlayerMove playerMove;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        playerMove = GetComponent<PlayerMove>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateSystem.Instance.AddUpdateAction(playerMove.Dash);
    }
}

[CreateAssetMenu(fileName = "UnitData_PlayerData", menuName = "Data/UnitData/PlayerData")]
public class PlayerData : UnitData
{

}
