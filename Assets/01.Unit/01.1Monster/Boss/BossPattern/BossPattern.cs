using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPattern
{
    public void ExcutePattern();
}

public class BossPattern
{
    protected List<IPattern> closePatterns = new();
    protected List<IPattern> farPatterns = new();
    public int patternIndex;

    public BossPattern(IPattern[] closePatterns, IPattern[] farPatterns)
    {
        this.closePatterns = closePatterns.ToList();
        this.farPatterns = farPatterns.ToList();
    }

    public void ExcuteClosePattern()
    {
        closePatterns[patternIndex].ExcutePattern();
    }

    public void ExcuteFarPattern()
    {
        farPatterns[patternIndex].ExcutePattern();
    }
}