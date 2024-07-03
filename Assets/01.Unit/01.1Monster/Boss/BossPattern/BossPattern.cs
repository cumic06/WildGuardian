using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public interface IPattern
{
    public bool IsEndPattern { get; set; }
    public void ExcutePattern();
}

public class BossPattern
{
    protected List<IPattern> closePatterns = new();
    protected List<IPattern> farPatterns = new();

    public BossPattern(IPattern[] closePatterns, IPattern[] farPatterns)
    {
        this.closePatterns = closePatterns.ToList();
        this.farPatterns = farPatterns.ToList();
    }

    public void ExcuteClosePattern()
    {
        int randomIndex = Random.Range(0, closePatterns.Count);
        if (closePatterns[randomIndex].IsEndPattern)
        {
            closePatterns[randomIndex].ExcutePattern();
        }
    }

    public void ExcuteFarPattern()
    {
        int randomIndex = Random.Range(0, farPatterns.Count);
        if (farPatterns[randomIndex].IsEndPattern)
        {
            farPatterns[randomIndex].ExcutePattern();
        }
    }
}