using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSystem : MonoBehaviour
{
    private const float cameraFollowSpeed = 10f;

    void Start()
    {
        UpdateSystem.Instance.AddUpdateAction(CameraMove);
    }

    private void CameraMove()
    {
        if (Player.Instance == null) return;
        Vector2 cameraPos = transform.position;
        Vector2 dir = (Vector2)Player.Instance.transform.position - cameraPos;
        Camera.main.transform.Translate(cameraFollowSpeed * Time.deltaTime * dir);
    }
}
