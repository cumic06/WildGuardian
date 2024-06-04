using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public enum GameState
{
    Play,
    Pause,
    GameClear,
    GameOver
}

public class GameStateEventBus : MonoBehaviour
{
    private static Dictionary<GameState, UnityEvent> gameStates = new();

    public static void Subscribe(GameState state, UnityAction action)
    {
        UnityEvent thisEvent;

        if (!gameStates.TryGetValue(state, out thisEvent))
        {
            thisEvent.AddListener(action);
        }
    }

    public static void UnSubscribe(GameState state, UnityAction action)
    {
        UnityEvent thisEvent;

        if (gameStates.TryGetValue(state, out thisEvent))
        {
            thisEvent.RemoveListener(action);
        }
    }

    public static void Publish(GameState state)
    {
        if (gameStates.ContainsKey(state))
        {
            gameStates[state]?.Invoke();
        }
    }
}
