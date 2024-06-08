using System.Collections.Generic;
using UnityEngine;
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
    private static Dictionary<GameState, Action> gameStates = new();

    public static void Subscribe(GameState state, Action action)
    {
        if (!gameStates.ContainsKey(state))
        {
            gameStates.Add(state, action);
        }
        else
        {
            gameStates[state] += action;
        }
    }

    public static void UnSubscribe(GameState state, Action action)
    {
        if (gameStates.ContainsValue(action))
        {
            gameStates[state] -= action;
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
