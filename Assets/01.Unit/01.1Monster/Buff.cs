using UnityEngine;

public class Buff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Monster monster))
        {
            monster.SpeedUp(3);
        }
    }
}