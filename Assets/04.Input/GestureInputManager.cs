using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureInputManager : MonoSingleton<GestureInputManager>
{

    [SerializeField] private float dragDistance = 0.3f;
    [SerializeField] private float dragDetectTime = 0.15f;

    [SerializeField] private float holdingTime = 1.25f;
    [SerializeField] private float holdDistance = 0.25f;
    private TouchInputManager TouchInput => TouchInputManager.Instance;

    public bool IsSwipe => TouchInput.TouchTime <= dragDetectTime && TouchInput.TouchOfViewDistance >= dragDistance;
    public bool IsHolding => TouchInput.IsTouching && TouchInput.FirstTouchPoint == TouchInput.LastTouchPoint && TouchInput.TouchTime >= holdingTime;

    private bool canSwipe;

    private bool canHold;
    private bool IsBeganHold;

    private Action swipeAction;

    private Action holdBeganAction;

    private Action holdingAction;

    private Action holdEndAction;
    private void Start()
    {
        TouchInput.AddTouchBeganAction(() => canSwipe = true);
        TouchInput.AddTouchBeganAction(() => canHold = true);
        TouchInput.AddTouchBeganAction(() => IsBeganHold = true);
        TouchInput.AddTouchEndAction(() => { if (!IsBeganHold) holdEndAction?.Invoke(); });
    }
    private void Update()
    {
        if (canSwipe && IsSwipe)
        {
            swipeAction?.Invoke();
            canSwipe = false;
        }

        if (holdDistance <= TouchInput.TouchOfViewDistance)
        {
            canHold = false;
        }

        if (canHold && IsHolding)
        {
            if (IsBeganHold)
            {
                holdBeganAction?.Invoke();
                IsBeganHold = false;
            }
            holdingAction?.Invoke();
        }
    }

    public void AddSwipeAction(Action action)
    {
        swipeAction += action;
    }
    public void AddHoldAction(Action action)
    {
        holdingAction += action;
    }

    public void AddHoldBeganAction(Action action)
    {
        holdBeganAction += action;
    }

    public void AddHoldEndAction(Action action)
    {
        holdEndAction += action;
    }
}
