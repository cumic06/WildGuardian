using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUISystem : MonoBehaviour
{
    [SerializeField] private Text timeText;

    private void Start()
    {
        TimeManager.Instance.timeChangeAction += TimeText;
    }

    private void TimeText()
    {
        timeText.text = $"PlayTime : {TimeManager.Instance.GetInGameTimeMin()}:{TimeManager.Instance.GetInGameTime():N2}";
    }
}
