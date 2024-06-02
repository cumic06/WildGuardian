using System;
using System.Collections;
using UnityEngine;

public class TouchInputManager : MonoSingleton<TouchInputManager>
{
#if UNITY_EDITOR
    private Vector2 clickRawPosition;
    private Vector2 clickLastPosition;
#endif
    public Vector2 FirstTouchPoint
    {
        get
        {
            Vector2 result = Vector2.zero;
#if UNITY_EDITOR
            result = clickRawPosition;
#elif UNITY_ANDROID
            if (IsTouching)
            {
                result = Input.GetTouch(0).rawPosition;
            }
#endif
            return result;
        }
    }

    public Vector2 FirstTouchPointOfView => Camera.main.ScreenToViewportPoint(FirstTouchPoint);

    public Vector2 LastTouchPoint
    {
        get
        {
            Vector2 result = Vector2.zero;
#if UNITY_EDITOR
            result = clickLastPosition;
#elif UNITY_ANDROID
            if (IsTouching)
            {
                result = Input.GetTouch(0).position;
            }
#endif
            return result;
        }
    }

    public Vector2 LastTouchPointOfView => Camera.main.ScreenToViewportPoint(LastTouchPoint);

    public Vector2 TouchDirection
    {
        get
        {
            Vector2 dir = LastTouchPointOfView - FirstTouchPointOfView;
            dir.Normalize();
            return dir;
        }
    }

    public float TouchDistance => Vector3.Distance(FirstTouchPoint, LastTouchPoint);

    public float TouchOfViewDistance => Vector3.Distance(FirstTouchPointOfView, LastTouchPointOfView);
    public bool IsTap => IsTouchUp && tapTime <= touchTime;

    public bool IsTouchDown
    {
        get
        {
            bool result = false;
#if UNITY_EDITOR
            result = Input.GetMouseButtonDown(0);
#elif UNITY_ANDROID
        if (IsTouching)
        {
           result = Input.GetTouch(0).phase == TouchPhase.Began;
        } 
#endif
            return result;
        }
    }
    public bool IsTouching
    {
        get
        {
            bool result;
#if UNITY_EDITOR
            result = Input.GetMouseButton(0);
#elif UNITY_ANDROID
            result = Input.touchCount > 0;
#endif
            return result;
        }
    }
    public bool IsTouchUp
    {
        get
        {
            bool result = false;
#if UNITY_EDITOR
            result = Input.GetMouseButtonUp(0);
#elif UNITY_ANDROID
            if (IsTouching)
            {
                result = Input.GetTouch(0).phase == TouchPhase.Ended;
            }    
#endif
            return result;
        }
    }


    [SerializeField] private float tapTime;

    private float touchTime;
    public float TouchTime => touchTime;


    private Action touchBegannAction;
    private Action touchingAction;
    private Action touchEndAction;

    private void Update()
    {
        if (IsTouchDown)
        {
#if UNITY_EDITOR
            clickRawPosition = Input.mousePosition;
#endif
            touchTime = 0.0f;
            touchBegannAction?.Invoke();
        }
        if (IsTouching)
        {
#if UNITY_EDITOR
            clickLastPosition = Input.mousePosition;
#endif
            touchingAction?.Invoke();
        }
        if (IsTouchUp)
        {
            touchEndAction?.Invoke();
        }

        touchTime += Time.deltaTime;
    }

    public void AddTouchBeganAction(Action action)
    {
        touchBegannAction += action;
    }

    public void AddTouchingAction(Action action)
    {
        touchingAction += action;
    }

    public void AddTouchEndAction(Action action)
    {
        touchEndAction += action;
    }
}
