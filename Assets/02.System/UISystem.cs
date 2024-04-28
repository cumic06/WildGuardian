using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    protected virtual void PopUpUI(GameObject ui, float endTime)
    {
        StartCoroutine(PopUp(ui, endTime));

        IEnumerator PopUp(GameObject ui, float endTime)
        {
            WaitForSeconds endWait = new(endTime);
            ui.SetActive(true);
            yield return endWait;
            ui.SetActive(false);
        }
    }
}
