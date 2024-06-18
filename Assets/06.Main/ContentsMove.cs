using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContentsMove : MonoBehaviour
{
    [SerializeField] private RectTransform myTransform;
    private float[] pivots = new float[3] { -11f, -0.18f, 10.6f };
    private ObseverFunc contents_ObseverFunc = new();
    private int index;
    private bool b = false;
    private void Start()
    {
        contents_ObseverFunc.OnMoveButton = (moveButton) => { this.index = moveButton.MoveIndex; b = true; };
        MoveButton.MovePanel_Obsever.AddObsever(contents_ObseverFunc);
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        float lerpPivot = 0;
        while (true)
        {
            yield return new WaitUntil(() => b);
            float X = Mathf.Lerp(myTransform.pivot.x, pivots[index], 0.9f);
            Func<bool> moveCheck = (myTransform.pivot.x > pivots[index]) ? () => { return myTransform.pivot.x > X; } : () => { return myTransform.pivot.x < X; };
            while (moveCheck())
            {
                lerpPivot = Mathf.Lerp(myTransform.pivot.x, pivots[index], 0.5f);
                myTransform.pivot = new(lerpPivot, 0);
                yield return null;
            }
            myTransform.pivot = new(pivots[index], 0);
            b = false;
        }
    }
}
