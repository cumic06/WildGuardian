using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoSingleton<TimeManager>
{
    private float inGameTime = 0.0f;
    private int inGameMin = 0;
    public Action timeChangeAction;

    private void Start()
    {
        UpdateSystem.Instance.AddFixedUpdateAction(AddTime);
    }

    private void AddTime()
    {
        inGameTime += Time.deltaTime;

        if (inGameTime >= 60)
        {
            inGameMin++;
            inGameTime = 0;
        }

        timeChangeAction?.Invoke();
    }

    public float GetInGameTime()
    {
        return inGameTime;
    }

    public int GetInGameTimeMin()
    {
        return inGameMin;
    }
}