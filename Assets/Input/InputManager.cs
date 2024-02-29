using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] private float swipeDetectTime;

    [SerializeField] private float swipeDetectMinDistance;

    [SerializeField] private float holdDetectTime;

    [SerializeField] private float holdDetectDistance;

    public bool IsTouching
    {
        get
        {
#if UNITY_EDITOR
            return Input.GetMouseButton(0);

#elif UNITY_ANDROID
            return Input.touchCount > 0;
#endif
        }
    }

    public bool IsTouchUp
    {
        get
        {

#if UNITY_EDITOR
            return Input.GetMouseButtonUp(0);
#elif UNITY_ANDROID
            if(Input.touchCount > 0)
            {
                return Input.touches[0].phase == TouchPhase.Ended;
            }
            return false;
#endif
        }
    }

    public bool IsTouchDown
    {
        get
        {
#if UNITY_EDITOR
            return Input.GetMouseButtonDown(0);
#elif UNITY_ANDROID
            if(Input.touchCount > 0)
            {
                return Input.touches[0].phase == TouchPhase.Began;
            }
            return false;
#endif
        }
    }

    public bool IsSwipe
    {
        get
        {
            return lastTouchTime < swipeDetectTime && DragDistance >= swipeDetectMinDistance && IsTouchUp;
        }
    }

    public bool IsHolding
    {
        get
        {
            return IsTouching && lastTouchPoint == firstTouchPoint && lastTouchTime >= holdDetectTime;
        }
    }

    public Vector2 DragDirection => (lastTouchPoint - firstTouchPoint).normalized;

    public float DragDistance => Vector2.Distance(lastTouchPoint, firstTouchPoint);
    public float ScaledDragDistance => Mathf.Min(Vector2.Distance(Camera.main.ScreenToWorldPoint(lastTouchPoint), Camera.main.ScreenToWorldPoint(firstTouchPoint)), 1);

    private Vector2 firstTouchPoint;
    public Vector2 FirstTouchPoint => firstTouchPoint;

    private Vector2 lastTouchPoint;
    public Vector2 CurrentTouchPoint => lastTouchPoint;

    public Action OnTouchDownAction;

    public Action OnTouchUpAction;

    public Action OnTouchingAction;

    public Action OnPressAction;

    private float lastTouchTime;


    private void Start()
    {
        StartCoroutine(Input_Cor());
    }

    public void OnTouchUp()
    {
        OnTouchUpAction?.Invoke();

        firstTouchPoint = Vector2.zero;
        lastTouchPoint = Vector2.zero;
        lastTouchTime = 0;
    }

    public void OnTouching()
    {
        lastTouchTime += Time.deltaTime;
        lastTouchPoint = GetTouchPoint();

        OnTouchingAction?.Invoke();
    }

    public void OnTouchDown()
    {
        firstTouchPoint = GetTouchPoint();

        OnTouchDownAction?.Invoke();
    }

    public Vector2 GetTouchPoint()
    {
#if UNITY_EDITOR
        return Input.mousePosition;
#elif UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            return Input.touches[0].position;
        }
        return Vector2.zero;
#endif
    }

    IEnumerator Input_Cor()
    {
        while (true)
        {
            if (IsTouchDown)
            {
                OnTouchDown();
            }
            if (IsTouching)
            {
                OnTouching();
            }
            if (IsTouchUp)
            {
                OnTouchUp();
            }
            yield return null;
        }
    }
}
