using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateSystem : MonoSingleton<UpdateSystem>
{
    private readonly HashSet<Action> updateHashSet = new();
    private readonly HashSet<Action> fixedUpdateHashSet = new();

    private void Start()
    {
        StartCoroutine(UpdateCor());
        StartCoroutine(FixedUpdateCor());
    }

    private IEnumerator UpdateCor()
    {
        while (true)
        {
            if (updateHashSet != null)
            {
                foreach (var updateAction in updateHashSet)
                {
                    updateAction?.Invoke();
                }
            }
            yield return null;
        }
    }

    private IEnumerator FixedUpdateCor()
    {
        WaitForFixedUpdate waitForFixedUpdate = new();

        while (true)
        {
            if (updateHashSet != null)
            {
                foreach (var fixedAction in fixedUpdateHashSet)
                {
                    fixedAction?.Invoke();
                }
            }
            yield return waitForFixedUpdate;
        }
    }


    public void AddUpdateAction(Action updateAction)
    {
        updateHashSet.Add(updateAction);
    }

    public void AddFixedUpdateAction(Action fixedUpdateAction)
    {
        fixedUpdateHashSet.Add(fixedUpdateAction);
    }

    public void RemoveUpdateAction(Action updateAction)
    {
        updateHashSet.Remove(updateAction);
    }

    public void RemoveFixedUpdateAction(Action fixedUpdateAction)
    {
        fixedUpdateHashSet.Remove(fixedUpdateAction);
    }
}