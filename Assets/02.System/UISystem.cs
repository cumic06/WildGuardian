using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    protected virtual void PopUpUI(GameObject ui, float endTime)
    {
        StartCoroutine(PopUp());

        IEnumerator PopUp()
        {
            WaitForSeconds endWait = new(endTime);
            ui.SetActive(true);
            yield return endWait;
            ui.SetActive(false);
        }
    }
}
