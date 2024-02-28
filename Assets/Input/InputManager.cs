using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] private float detect_drag_time;
    [SerializeField] private float detect_drag_min;

    public Vector2 FirstTouchPoint;

    public Vector2 CurrentTouchPoint;

    public Vector2 TouchDirection => (CurrentTouchPoint - FirstTouchPoint).normalized;
    public float TouchDistance => Mathf.Clamp(Vector2.Distance(CurrentTouchPoint, FirstTouchPoint) / detect_drag_min, 0, 10);

    private float currentSlideTime;

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

    public void Update()
    {
        if (IsTouchDown())
        {
            FirstTouchPoint = GetTouchPoint();
            currentSlideTime = 0;
        }
        if (IsTouching)
        {
            CurrentTouchPoint = GetTouchPoint();
        }
        currentSlideTime += Time.deltaTime;
    }

    public bool IsTouchDown()
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

    public bool IsTouchUp()
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

    public bool IsSlide()
    {
        return currentSlideTime < detect_drag_time && TouchDistance >= 10 && IsTouchUp();
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

    public void TouchInputValueReset()
    {
        FirstTouchPoint = Vector2.zero;
        CurrentTouchPoint = Vector2.zero;
    }
}
