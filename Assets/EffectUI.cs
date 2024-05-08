using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectUI : UISystem
{
    public static EffectUI Instance;
    [SerializeField] private Image effectUI;

    private void Awake()
    {
        Instance = GetComponent<EffectUI>();
    }

    public void FlickrImage(Color color)
    {
        effectUI.color = color;
        StartCoroutine(StateFlickrImage());

        IEnumerator StateFlickrImage()
        {
            WaitForSeconds flickrWait = new(0.1f);
            for (int i = 0; i < 2; i++)
            {
                effectUI.gameObject.SetActive(true);
                yield return flickrWait;
                effectUI.gameObject.SetActive(false);
                yield return flickrWait;
            }
        }
    }
}
