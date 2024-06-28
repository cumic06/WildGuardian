using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class InventoryMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform GridPanel;
    private float posY;
    private float posY2;
    List<float> Drag = new List<float>();
    public void Start()
    {
        //StartCoroutine(GridMove());
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Drag.Add(eventData.position.normalized.y);
        //Debug.Log("드래그 시작");
        //if (posY != 0 && posY > eventData.position.normalized.y)
        //{
        //    posY = eventData.position.normalized.y;
        //    GridPanel.position -= new Vector3(0, posY * 10, 0);
        //}
        //else
        //{
        //    posY = eventData.position.normalized.y;
        //    GridPanel.position += new Vector3(0, posY * 10, 0);
        //}
    }

    public void OnDrag(PointerEventData eventData)
    {
        Drag.Add(eventData.position.normalized.y);
        if (Drag.Count > 2)
        {
            if((Drag[Drag.Count - 2] > Drag[Drag.Count - 1]))
            {
                GridPanel.position -= new Vector3(0, 10, 0);
            }
            else
                GridPanel.position += new Vector3(0, 10, 0);
        }
        //if (posY != 0 && posY > eventData.position.normalized.y)
        //{
        //    posY = eventData.position.normalized.y;
        //    GridPanel.position -= new Vector3(0, posY * 10, 0);
        //}
        //else
        //{
        //    posY = eventData.position.normalized.y;
        //    GridPanel.position += new Vector3(0, posY * 10, 0);
        //}
        //posY = eventData.position.normalized.y;
        //posY2 = eventData.position.normalized.y;
        //GridPanel.position += new Vector3(0, posY * 10, 0);
        //Debug.Log(eventData.position.normalized);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Drag.Clear();
        //Debug.Log($"{Drag.First()}:{Drag.Last()}");
        //if (Drag.First() > Drag.Last())
        //{
        //    GridPanel.position -= new Vector3(0, 10, 0);
        //}
        //else
        //{
        //    GridPanel.position += new Vector3(0, 10, 0);
        //}
        //posY = eventData.position.normalized.y;
        //GridPanel.position += new Vector3(0, posY * 10, 0);
    }

    IEnumerator GridMove()
    {
        while (true)
        {
            yield return null;

        }
    }
}
