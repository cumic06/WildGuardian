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
        GameStateEventBus.Subscribe(GameState.Pause, GameTimeStop);
        GameStateEventBus.Subscribe(GameState.Play, GameTimePlay);
        GameStateEventBus.Subscribe(GameState.GameOver, GameTimeStop);
        LevelSystem.Instance.OnChangeLevel += () => GameStateEventBus.Publish(GameState.Pause);
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

    public void GameTimeStop()
    {
        Time.timeScale = 0;
    }

    public void GameTimePlay()
    {
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        GameStateEventBus.UnSubscribe(GameState.Pause, GameTimeStop);
        GameStateEventBus.UnSubscribe(GameState.Play, GameTimePlay);
        GameStateEventBus.UnSubscribe(GameState.GameOver, GameTimeStop);
    }
}