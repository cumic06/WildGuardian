using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackPower;

    public void SetAttackPower(float value)
    {
        attackPower = value;
    }
}
