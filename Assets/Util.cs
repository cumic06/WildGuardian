using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static void LookAt2D(this Transform myTransform, Vector3 targetPos)
    {
        Vector2 dir = targetPos - myTransform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion lookRot = Quaternion.Euler(new Vector3(0, 0, angle));
        myTransform.rotation = lookRot;
    }
}
